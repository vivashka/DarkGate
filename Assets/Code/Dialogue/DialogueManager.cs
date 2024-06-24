using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    public bool isDialoguePlaying { get; private set; }

    public static DialogueManager instance { get; private set; }

    [SerializeField] private PlayerHealth playerHealth; // Reference to PlayerHealth

    private string currentDialogueName;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Найдено более одного диалога в сцене.");
        }

        instance = this;
    }

    private void Start()
    {
        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if (!isDialoguePlaying)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentStory.currentChoices.Count > 0)
            {
                // Confirm the currently selected choice
                MakeChoice(EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex());
            }
            else
            {
                ContinueStory();
            }
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON, string dialogueName)
    {
        currentStory = new Story(inkJSON.text);
        currentDialogueName = dialogueName;
        isDialoguePlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError(
                $"Вариантов ответа больше, чем UI поддерживает. Количество вариантов: {currentChoices.Count}");
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        if (choiceIndex < 0 || choiceIndex >= currentStory.currentChoices.Count)
        {
            Debug.LogError("Invalid choice index: " + choiceIndex);
            return;
        }

        currentStory.ChooseChoiceIndex(choiceIndex);

        // Проверяем, если первый вариант ответа и текущий диалог - тот, который должен восстанавливать здоровье
        if (choiceIndex == 0 && currentDialogueName == "npc_health_restore")
        {
            playerHealth.RestoreHealth(playerHealth.maxHealth);
        }

        ContinueStory();
    }
}