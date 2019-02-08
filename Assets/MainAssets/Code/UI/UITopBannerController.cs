using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITopBannerController : UIController
{
    [SerializeField]
    private TextMeshProUGUI shotsText, timeText;

    public static UITopBannerController instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Show();
    }

    private void Update()
    {
        shotsText.text = "Shots: " + GameController.instance.shotsFired.ToString("00");
        timeText.text = "Time: " + GameController.instance.timeTaken.ToString("0000") + "s";
    }

    public void Hide()
    {
        Close(this.GetComponent<CanvasGroup>());
    }

    public void Show()
    {
        Open(this.GetComponent<CanvasGroup>());
    }

    public void PauseGame()
    {
        UIPauseController.instance.PauseGame();
    }

}
