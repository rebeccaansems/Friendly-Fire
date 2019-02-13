using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITopBannerController : UIController
{
    [SerializeField]
    private TextMeshProUGUI shotsText, parText, levelNameText;

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
        if (shotsText != null)
        {
            shotsText.text = "Shots: " + GameController.instance.shotsFired.ToString("00");
            parText.text = "Shot Par: " + GameController.instance.currentLevel.starLevels[0].ToString("00");
            levelNameText.text = GameController.instance.currentLevel.levelName;
        }
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
        if (shotsText != null)
        {
            UIPauseController.instance.PauseGame();
        }
        else
        {
            UISettingsController.instance.Show();
        }
    }
}
