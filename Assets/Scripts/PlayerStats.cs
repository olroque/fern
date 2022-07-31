using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int maxHealth = 50;
    [SerializeField] int maxMagic = 50;
    [SerializeField] int maxStamina = 50;

    int currentHealth;
    int currentMagic;
    int currentStamina;

    Health health;
    Magic magic;
    Stamina stamina;

    void Awake() 
    {
        health = GetComponent<Health>();
        magic = GetComponent<Magic>();
        stamina = GetComponent<Stamina>();
    }

    void Start() 
    {
        currentHealth = maxHealth;    
        currentMagic = maxMagic;    
        currentStamina = maxStamina;    
    }

    // Get the maximums stats

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetMaxMagic()
    {
        return maxMagic;
    }

    public int GetMaxStamina()
    {
        return maxStamina;
    }

    // Get current stats 

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetCurrentMagic()
    {
        return currentMagic;
    }

    public int GetCurrentStamina()
    {
        return currentStamina;
    }
    
    // Reduce stats 

    public void ReduceHP(int hpCost)
    {
        currentHealth -= hpCost;
    }

    public void ReduceMP(int mpCost)
    {
        currentMagic -= mpCost;
    }

    public void ReduceSP(int spCost)
    {
        currentStamina -= spCost;
    }
    
    // Zero stats 

    public void ZeroeHP()
    {
        currentHealth = 0;
    }

    public void ZeroeMP()
    {
        currentMagic = 0;
    }

    public void ZeroeSP()
    {
        currentStamina = 0;
    }

    // Apply potion 

    public void ApplyHealthPotion(int potionIncrease)
    {
        if (maxHealth < currentHealth + potionIncrease)
        {
            currentHealth = maxHealth;
        }
        else 
        {
            currentHealth += potionIncrease;
        }
    }

    public void ApplyMagicPotion(int potionIncrease)
    {
        if (maxMagic < currentMagic + potionIncrease)
        {
            currentMagic = maxMagic;
        }
        else 
        {
            currentMagic += potionIncrease;
        }
    }

    public void ApplyStaminaPotion(int potionIncrease)
    {
        if (maxStamina < currentStamina + potionIncrease)
        {
            currentStamina = maxStamina;
        }
        else 
        {
            currentStamina += potionIncrease;
        }
    }
}