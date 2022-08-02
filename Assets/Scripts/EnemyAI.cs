using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float forwardMovement = 1f;
    [SerializeField] float angle;
    
    float smooth = 5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 direction = new Vector3(0f, 0f, forwardMovement).normalized;
        Quaternion target = Quaternion.Euler(0f, angle, 0f);

        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
    }
}
