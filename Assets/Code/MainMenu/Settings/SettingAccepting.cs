using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingAccepting : MonoBehaviour
{
    public GameObject menu;
    public TMP_Dropdown languageDropdown;

    public void OnReturn()
    {
        menu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnAccept()
    {
        if (languageDropdown == null)
        {
            Debug.LogError("languageDropdown не назначен.");
            return;
        }

        if (LocalizationManager.instance == null)
        {
            Debug.LogError("LocalizationManager.instance не существует.");
            return;
        }

        // Получаем выбранный язык из Dropdown
        string selectedLanguage = languageDropdown.options[languageDropdown.value].text;

        // Меняем язык в LocalizationManager
        LocalizationManager.instance.ChangeLanguage(selectedLanguage);

        // Обновляем все локализованные тексты
        LocalizedText[] localizedTexts = FindObjectsOfType<LocalizedText>();
        foreach (LocalizedText localizedText in localizedTexts)
        {
            localizedText.UpdateText();
        }

        // Возвращаемся в предыдущее меню
        menu.SetActive(true);
        gameObject.SetActive(false);
    }
}