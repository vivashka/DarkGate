using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuEsc : MonoBehaviour
{

    public GameObject menuPanel;

    private bool isMenuActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuActive = !isMenuActive;
            menuPanel.SetActive(isMenuActive);
        }
    }

}
