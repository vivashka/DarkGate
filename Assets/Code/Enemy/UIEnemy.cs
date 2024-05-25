using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemy : MonoBehaviour
{
    public Slider healthBar;
    public EnemyHealth enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = enemyHealth.maxhealth;
        healthBar.value = enemyHealth.health;
        enemyHealth.healthHandler += OnHit;
    }

    private void OnHit(int hit)
    {
        healthBar.value = enemyHealth.health;
    }
}
