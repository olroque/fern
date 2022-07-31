using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{

    [SerializeField] float exhaustRate = 0.2f;
    [SerializeField] int sprintCost = 1;

    int maxStamina;
    int currentStamina;

    public bool isSprinting;

    Coroutine staminaCoroutine;

    PlayerStats playerStats;

    void Awake() 
    {
        playerStats = GetComponent<PlayerStats>();    
    }

    void Start() 
    {
        maxStamina = playerStats.GetMaxStamina();
        currentStamina = playerStats.GetCurrentHealth();
    }
    
    void Update() 
    {
        Sprint();
    }

    void Sprint()
    {
        if (isSprinting && staminaCoroutine == null)
        {
            staminaCoroutine = StartCoroutine(ReduceStamina());
        }
        else if (!isSprinting && staminaCoroutine != null)
        {
            StopCoroutine(staminaCoroutine);
            staminaCoroutine = null;
        }
    }

    IEnumerator ReduceStamina()
    {
        while (true && currentStamina >= Mathf.Epsilon)
        {
            playerStats.ReduceSP(sprintCost);
            yield return new WaitForSeconds(exhaustRate);
        }
    }
}