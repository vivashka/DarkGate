using UnityEngine;

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
