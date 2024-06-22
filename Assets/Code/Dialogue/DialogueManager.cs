using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // Для UI
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    // Для выбора сообщения
    private Message[] currentMessages;
    private Actor[] currentActors;
    private int activeMessage = 0;
    public static bool isActive = false;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages; // Берёт из MessageTrigger, то что поставили в скрипт
        currentActors = actors; // Аналогично
        activeMessage = 0;
        isActive = true;
        
        // Показываем UI элементы при открытии диалога
        backgroundBox.gameObject.SetActive(true);

        Debug.Log("Диалог начат. Загружено сообщений: " + messages.Length);
        DisplayMessage();
    }

    void DisplayMessage() // Срабатывает при открытии диалога
    {
        Message messageToDisplay = currentMessages[activeMessage]; // Выбор сообщения из массива
        messageText.text = messageToDisplay.message; // Связь с UI

        Actor actorToDisplay = currentActors[messageToDisplay.actorId]; // Аналогично
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }

    public void NextMessage()
    {
        activeMessage++; // Следующее сообщение
        if (activeMessage < currentMessages.Length) // Диалог не кончился
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Диалог завершён.");
            isActive = false;
            
            // Скрываем UI элементы при завершении диалога
            backgroundBox.gameObject.SetActive(false);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // Скрываем UI элементы при старте
        backgroundBox.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isActive)
        {
            NextMessage();
        }
    }
}
