using System;
using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject visualCue;
    [SerializeField] private TextAsset inkJSON;
    
    
    private bool isPlayerInRange;

    private void Awake()
    {
        isPlayerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerInRange && !DialogueManager.instance.isDialoguePlaying)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
               DialogueManager.instance.EnterDialogueMode(inkJSON);
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
}