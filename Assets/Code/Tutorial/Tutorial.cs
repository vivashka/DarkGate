using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject player;
    public Image wasdImage; // Image для первой фазы туториала
    public Image shiftWasdImage; // Image для второй фазы туториала
    public Image leftClickImage; // Image для третьей фазы туториала

    private int currentPhase = 0;
    private bool wPressed = false;
    private bool aPressed = false;
    private bool sPressed = false;
    private bool dPressed = false;
    private bool shiftPressed = false;

    void Start()
    {
        // Скрываем все туториальные изображения в начале игры
        wasdImage.gameObject.SetActive(false);
        shiftWasdImage.gameObject.SetActive(false);
        leftClickImage.gameObject.SetActive(false);

        // Показываем первую фазу туториала
        ShowTutorialPhase(0);
    }

    void Update()
    {
        // Проверяем выполнение условий для каждой фазы туториала
        if (currentPhase == 0)
        {
            if (Input.GetKeyDown(KeyCode.W)) wPressed = true;
            if (Input.GetKeyDown(KeyCode.A)) aPressed = true;
            if (Input.GetKeyDown(KeyCode.S)) sPressed = true;
            if (Input.GetKeyDown(KeyCode.D)) dPressed = true;

            if (wPressed && aPressed && sPressed && dPressed)
            {
                CompleteTutorialPhase();
            }
        }
        else if (currentPhase == 1)
        {
            if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
            {
                CompleteTutorialPhase();
            }
        }
        else if (currentPhase == 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CompleteTutorialPhase();
            }
        }
    }

    void ShowTutorialPhase(int phase)
    {
        // Скрываем все изображения туториала
        wasdImage.gameObject.SetActive(false);
        shiftWasdImage.gameObject.SetActive(false);
        leftClickImage.gameObject.SetActive(false);

        // Показываем текущее изображение туториала
        switch (phase)
        {
            case 0:
                wasdImage.gameObject.SetActive(true);
                break;
            case 1:
                shiftWasdImage.gameObject.SetActive(true);
                break;
            case 2:
                leftClickImage.gameObject.SetActive(true);
                break;
        }
    }

    void CompleteTutorialPhase()
    {
        currentPhase++;

        if (currentPhase < 3)
        {
            ShowTutorialPhase(currentPhase);
        }
        else
        {
            // Все фазы завершены, скрываем все туториальные изображения
            wasdImage.gameObject.SetActive(false);
            shiftWasdImage.gameObject.SetActive(false);
            leftClickImage.gameObject.SetActive(false);
        }
    }
}