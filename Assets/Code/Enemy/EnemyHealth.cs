using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int maxhealth = 10;
    public int health = 10;

    public delegate void EnemyHealthHandler(int health);

    public EnemyHealthHandler healthHandler;

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthHandler?.Invoke(health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
