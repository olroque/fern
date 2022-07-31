using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float bulletLifetime = 5f;
    [SerializeField] float firingRate = 0.2f;

    [SerializeField] int bulletCost = 1;

    public bool isFiring;

    Coroutine firingCoroutine;

    Magic magic;
    PlayerStats playerStats;

    void Awake() 
    {
        magic = GetComponent<Magic>();
        playerStats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }

    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            Rigidbody rb = instance.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = transform.forward * bulletSpeed;
                playerStats.ReduceMP(bulletCost);
            }

            Destroy(instance, bulletLifetime);
            yield return new WaitForSeconds(firingRate);
        }
    }
}
