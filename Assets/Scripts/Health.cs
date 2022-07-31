using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    int maxHealth;
    int currentHealth;

    PlayerStats playerStats;
    GameSession gameSession;

    void Awake() 
    {
        gameSession = FindObjectOfType<GameSession>();
        playerStats = GetComponent<PlayerStats>();
    }

    void Start()
    {
        maxHealth = playerStats.GetMaxHealth();  
        currentHealth = playerStats.GetCurrentHealth();  
    }

    void OnTriggerEnter(Collider other) 
    {
        ProcessDamage(other);
        // HealthPotion(other);
    }

    void ProcessDamage(Collider other) 
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            if (gameObject.tag == "Player" && other.tag == "Bullet")
            {
                return;
            }
            else
            {
                TakeDamage(damageDealer.GetDamage());
            }
        }
    }

    void TakeDamage(int damage)
    {
        if (playerStats.GetCurrentHealth() - damage <= 0)
        {
            if (gameObject.tag == "Player")
            {
                currentHealth = 0;
                Destroy(gameObject);
                gameSession.ReloadGame();
                // int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                // SceneManager.LoadScene(currentSceneIndex);

            }
            else
            {
                Destroy(transform.parent.gameObject);
            }
        }
        else 
        {
            playerStats.ReduceHP(damage);
        }
    }
}
