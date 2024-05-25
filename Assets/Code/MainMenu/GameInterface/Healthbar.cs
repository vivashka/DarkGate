using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider healthBar;

    public PlayerHealth playerHealth;

    void Start()
    {
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.health;
        playerHealth.healthHandler += OnHit;
    }

    private void OnHit(int hit)
    {
        healthBar.value = playerHealth.health;
    }
}
