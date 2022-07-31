using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{

    [Header("Player Stats")]
    [SerializeField] PlayerStats playerStats;

    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] TextMeshProUGUI hpText;

    [Header("Stamina")]
    [SerializeField] Slider staminaSlider;
    [SerializeField] TextMeshProUGUI spText;

    [Header("Magic")]
    [SerializeField] Slider magicSlider;
    [SerializeField] TextMeshProUGUI mpText;

    int maxHealth;
    int maxMagic;
    int maxStamina;

    int currentHealth;
    int currentMagic;
    int currentStamina;
    
    void Start()
    {
        maxHealth = playerStats.GetMaxHealth();
        maxMagic = playerStats.GetMaxMagic();
        maxStamina = playerStats.GetMaxStamina();

        healthSlider.maxValue = maxHealth;
        magicSlider.maxValue = maxMagic;
        staminaSlider.maxValue = maxStamina;
    }

    void Update()
    {
        healthSlider.value = playerStats.GetCurrentHealth();
        hpText.text = playerStats.GetCurrentHealth().ToString() + " / " + maxHealth.ToString();


        magicSlider.value = playerStats.GetCurrentMagic();
        mpText.text = playerStats.GetCurrentMagic().ToString() + " / " + maxMagic.ToString();

        staminaSlider.value = playerStats.GetCurrentStamina();
        spText.text = playerStats.GetCurrentStamina().ToString() + " / " + maxStamina.ToString();
    }
}
