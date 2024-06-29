using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject visualCue;
    [SerializeField] private TextAsset inkJSON_EN;
    [SerializeField] private TextAsset inkJSON_RU;
    [SerializeField] private string dialogueName; // Добавляем имя диалога

    private bool isPlayerInRange;
    private TextAsset currentInkJSON;

    private void Awake()
    {
        isPlayerInRange = false;
        visualCue.SetActive(false);

        // Задаем JSON по умолчанию
        SetCurrentInkJSON();
    }

    private void Update()
    {
        if (isPlayerInRange && !DialogueManager.instance.isDialoguePlaying)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                DialogueManager.instance.EnterDialogueMode(currentInkJSON, dialogueName);
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            isPlayerInRange = false;
        }
    }

    public void SetCurrentInkJSON()
    {
        // Заменяем JSON в зависимости от выбранного языка
        switch (LocalizationManager.instance.CurrentLanguage)
        {
            case "en":
                currentInkJSON = inkJSON_EN;
                break;
            case "ru":
                currentInkJSON = inkJSON_RU;
                break;
            default:
                Debug.LogError("Unsupported language in DialogueTrigger");
                break;
        }
    }
}