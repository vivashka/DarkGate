using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image[] hearts; // Массив для хранения ссылок на все сердца

    public void UpdateHealthUI(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].enabled = true; // Показывает полное сердце
            }
            else
            {
                hearts[i].enabled = false; // Скрывает сердце
            }
        }
    }
}