using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueTrigger trigger;

    private void OnCollisionEnter(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player") == true)
            trigger.StartDialogue();
    }
}
