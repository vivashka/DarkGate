using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 8;
    public int health = 8;
    int index;

    public delegate void PlayerHealthHandler(int health);
    public event PlayerHealthHandler healthHandler;

    public HealthUI healthUI;

    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
        healthHandler += UpdateUI; // Подпишитесь на событие обновления UI
        healthHandler?.Invoke(health); // Инициируем обновление UI в начале
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0) health = 0;
        healthHandler?.Invoke(health);
        if (health <= 0)
        {
            SceneManager.LoadScene(index);
        }
    }

    void UpdateUI(int currentHealth)
    {
        if (healthUI != null)
        {
            healthUI.UpdateHealthUI(currentHealth);
        }
        else
        {
            Debug.LogError("HealthUI is not assigned in PlayerHealth.");
        }
    }
}