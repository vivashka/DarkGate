using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damaged : MonoBehaviour
{
    Entity entity;

    public delegate void HealthHandler();

    public HealthHandler healthHandler;

    private void Start()
    {
        entity = GetComponent<Entity>();
    }

    public void TakeDamage(int damage)
    {
        entity.health -= damage;
        healthHandler?.Invoke();
        if (entity.health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Disarrange()
    {

    }
}
