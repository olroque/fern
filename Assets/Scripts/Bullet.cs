using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
    
    void OnTriggerEnter(Collider other) 
    {
        if (other.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
