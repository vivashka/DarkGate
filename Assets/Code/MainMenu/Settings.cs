using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject buttons;
    public GameObject settings;

    public void ChangeItems()
    {
        settings.SetActive(true);
        buttons.SetActive(false);
    }
}
