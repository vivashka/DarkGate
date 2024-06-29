using UnityEngine;
using TMPro;

public class LocalizedText : MonoBehaviour
{
    [SerializeField] private string key;

    private TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();

        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshProUGUI компонент не найден на объекте " + gameObject.name);
            return;
        }

        LocalizationManager.instance.ChangeLanguage("ru");  // Установите язык по умолчанию
        UpdateText();
    }

    private void OnEnable()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        if (textMeshPro != null && LocalizationManager.instance != null)
        {
            textMeshPro.text = LocalizationManager.instance.GetLocalizedValue(key);
        }
    }
}