using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamagedState : MonoBehaviour
{
    public delegate bool HealthHandler();

    public HealthHandler healthHandler;

    public Enemy enemy;

    public void TakeDamage(int damage)
    {
        enemy.health -= damage;
        healthHandler?.Invoke();
        if (enemy.health <= 0)
        {
           Destroy(gameObject);
        }
    }

    public void Disarrange()
    {

    }
}
