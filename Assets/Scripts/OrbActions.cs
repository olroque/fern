using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbActions : MonoBehaviour
{

    [SerializeField] int healthIncrease = 10;
    [SerializeField] int magicIncrease = 10;
    [SerializeField] int staminaIncrease = 10;

    PlayerStats playerStats;

    void OnTriggerEnter(Collider other) 
    {
        playerStats = other.GetComponent<PlayerStats>(); 

        if (gameObject.tag == "Health Potion" && other.tag == "Player")
        {
            playerStats.ApplyHealthPotion(healthIncrease);
        }

        if (gameObject.tag == "Magic Potion" && other.tag == "Player")
        {
            playerStats.ApplyMagicPotion(magicIncrease);
        }

        if (gameObject.tag == "Stamina Potion" && other.tag == "Player")
        {
            playerStats.ApplyStaminaPotion(staminaIncrease);
        }

        Destroy(gameObject);
    }
}
