using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITopBannerController : UIController
{
    [SerializeField]
    private TextMeshProUGUI shotsText, timeText;
    [SerializeField]
    private CanvasGroup topBannerPanel;

    public static UITopBannerController instance;

    private void Awake()
    {
        instance = this;
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

}
