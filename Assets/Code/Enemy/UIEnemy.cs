using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemy : MonoBehaviour
{
    public Slider healthBar;
    public Damaged enemyHit;
    public Enemy health;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = health.maxHealth;
        healthBar.value = health.health;
        enemyHit.healthHandler += OnHit;
    }

    private void OnHit()
    {
        healthBar.maxValue = health.maxHealth;
        healthBar.value = health.health;
    }
}
