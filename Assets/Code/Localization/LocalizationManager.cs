using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager instance;

    public TextAsset localizationEn;
    public TextAsset localizationRu;

    private Dictionary<string, string> localizedText;
    private string missingTextString = "Локализованный текст не найден";
    public string CurrentLanguage { get; private set; } = "ru";  // Добавляем текущее значение языка

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void ChangeLanguage(string language)
    {
        switch (language)
        {
            case "English":
                LoadLocalizedText("en");
                CurrentLanguage = "en";
                break;
            case "Русский":
                LoadLocalizedText("ru");
                CurrentLanguage = "ru";
                break;
            default:
                Debug.Log("Unsupported language: " + language);
                break;
        }
        
        if (DialogueManager.instance != null)
        {
            DialogueManager.instance.UpdateDialogueTriggers();
        }
    }


    public void LoadLocalizedText(string language)
    {
        localizedText = new Dictionary<string, string>();
        TextAsset targetFile = null;

        switch (language)
        {
            case "en":
                targetFile = localizationEn;
                break;
            case "ru":
                targetFile = localizationRu;
                break;
            default:
                Debug.LogError("Unsupported language: " + language);
                return;
        }

        if (targetFile != null)
        {
            string dataAsJson = targetFile.text;
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

            for (int i = 0; i < loadedData.items.Length; i++)
            {
                localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
            }

            Debug.Log("Файл локализации загружен успешно.");
        }
        else
        {
            Debug.LogError("Файл локализации не назначен.");
        }
    }

    public string GetLocalizedValue(string key)
    {
        string result = missingTextString;
        if (localizedText.ContainsKey(key))
        {
            result = localizedText[key];
        }

        return result;
    }
}

[System.Serializable]
public class LocalizationData
{
    public LocalizationItem[] items;
}

[System.Serializable]
public class LocalizationItem
{
    public string key;
    public string value;
}
