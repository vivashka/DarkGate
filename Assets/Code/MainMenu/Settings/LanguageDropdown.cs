using UnityEngine;
using TMPro;

public class LanguageDropdown : MonoBehaviour
{
    public TMP_Dropdown languageDropdown;

    private void Start()
    {
        languageDropdown.onValueChanged.AddListener(OnLanguageChanged);
    }

    public void OnLanguageChanged(int index)
    {
        string selectedLanguage = languageDropdown.options[index].text;
        LocalizationManager.instance.ChangeLanguage(selectedLanguage);

        // Обновляем все локализованные тексты
        LocalizedText[] localizedTexts = FindObjectsOfType<LocalizedText>();
        foreach (LocalizedText localizedText in localizedTexts)
        {
            localizedText.UpdateText();
        }
    }
}