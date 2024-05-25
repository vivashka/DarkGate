using UnityEngine;
using UnityEngine.SceneManagement;
using static PlayerHealth;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health = 10;
    int index;

    public delegate void PlayerHealthHandler(int health);

    public PlayerHealthHandler healthHandler;

    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthHandler?.Invoke(health);
        if (health <= 0)
        {
            SceneManager.LoadScene(index);
        }
    }
}