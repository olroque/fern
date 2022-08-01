using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{

    [SerializeField] float exhaustRate = 0.2f;
    [SerializeField] int sprintCost = 1;

    int maxStamina;
    int currentStamina;

    public bool isSprintButtonDown;
    public bool isSprinting;

    Coroutine staminaCoroutine;

    PlayerStats playerStats;
    ThirdPersonMovement thirdPersonMovement;

    void Awake() 
    {
        playerStats = GetComponent<PlayerStats>();    
        thirdPersonMovement = GetComponent<ThirdPersonMovement>();    
    }
    
    void Update() 
    {
        SprintChecker();
        Sprint();
    }

    void SprintChecker()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isSprintButtonDown = true;
        } 
        else if (Input.GetButtonUp("Fire2"))
        {
            isSprintButtonDown = false;
            isSprinting = false;
        }
    }
    
    void Sprint()
    {
        if (isSprintButtonDown && staminaCoroutine == null)
        {
            staminaCoroutine = StartCoroutine(ReduceStamina());
        }
        else if (!isSprintButtonDown && staminaCoroutine != null)
        {
            StopCoroutine(staminaCoroutine);
            staminaCoroutine = null;
        }
    }

    IEnumerator ReduceStamina()
    {
        while (true && playerStats.GetCurrentStamina() >= Mathf.Epsilon && thirdPersonMovement.isMoving)
        {
            isSprinting = true;
            playerStats.ReduceSP(sprintCost);
            yield return new WaitForSeconds(exhaustRate);
        }
        isSprinting = false;
    }
}