using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SettingAccepting : MonoBehaviour
{
    public GameObject menu;
    public void OnReturn()
    {
        menu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnAccept() { }
}
