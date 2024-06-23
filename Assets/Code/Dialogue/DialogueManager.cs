using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Story currentStory;
    public bool isDialoguePlaying {get; private set; }
    
    public static DialogueManager instance {get; private set; }

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
    }

    private void Update()
    {
        if (!isDialoguePlaying)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            ContinueStory();
            Debug.Log("Continuing dialogue");
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        isDialoguePlaying = true;
        dialoguePanel.SetActive(true);

        Debug.Log("Entered dialogue mode");
        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);
        
        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        
        Debug.Log("Exited dialogue mode");
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            Debug.Log("Continuing story: " + dialogueText.text);
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
            Debug.Log("Story ended, exiting dialogue mode");
        }
    }
}
