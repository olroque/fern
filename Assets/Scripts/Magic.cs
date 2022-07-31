using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    int maxMagic;
    int currentMagic;

    PlayerStats playerStats;

    void Awake() 
    {
        playerStats = GetComponent<PlayerStats>();
    }
    
    void Start() 
    {
        maxMagic = playerStats.GetMaxMagic();
        currentMagic = playerStats.GetCurrentHealth();
    }
}
