using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float sprintSpeed = 24f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Vector3 velocity;

    bool isGrounded; 
    public bool isMoving; 

    GameSession gameSession;
    Shooter shooter;

    PlayerStats playerStats;
    Health health;
    Magic magic;
    Stamina stamina;


    void Awake()
    {
        shooter = GetComponent<Shooter>();
        playerStats = GetComponent<PlayerStats>();
        stamina = GetComponent<Stamina>();
        magic = GetComponent<Magic>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        Gravity();
        Move();
        Jump();
        Fire();
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameSession.ReloadGame();
        }
    }

    void Gravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) 
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            isMoving = true;

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle ,0f) * Vector3.forward;

            if (stamina.isSprinting)
            {
                controller.Move(moveDir.normalized * sprintSpeed * Time.deltaTime);
            }
            else
            {
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }
        } 
        else 
        {
            isMoving = false;
        }


        controller.Move(velocity * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
    }

    void Fire()
    {
        int currentMagic = playerStats.GetCurrentMagic();
        if ((Input.GetButtonDown("Fire1")) && (shooter != null) && currentMagic >= Mathf.Epsilon) 
        {
            shooter.isFiring = true;
        }
        else if (Input.GetButtonUp("Fire1") || currentMagic <= Mathf.Epsilon)
        {
            shooter.isFiring = false;
        }
    }
}
