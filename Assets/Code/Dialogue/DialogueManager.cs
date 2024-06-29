using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;
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

    [SerializeField] private PlayerHealth playerHealth;

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
        for (int i = 0; i < choices.Length; i++)
        {
            choicesText[i] = choices[i].GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    private void Update()
    {
        if (!isDialoguePlaying) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentStory.currentChoices.Count > 0)
            {
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
            Debug.LogError($"Вариантов ответа больше, чем UI поддерживает. Количество вариантов: {currentChoices.Count}");
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

        if (choiceIndex == 0 && currentDialogueName == "npc_health_restore")
        {
            playerHealth.RestoreHealth(playerHealth.maxHealth);
        }

        ContinueStory();
    }
    
    public void UpdateDialogueTriggers()
    {
        DialogueTrigger[] triggers = FindObjectsOfType<DialogueTrigger>();
        foreach (DialogueTrigger trigger in triggers)
        {
            trigger.SetCurrentInkJSON();
        }
    }
}
