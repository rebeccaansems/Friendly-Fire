using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameoverController : UIController
{
    [SerializeField]
    private TextMeshProUGUI mainText = null, headerText = null;

    public static UIGameoverController instance;

    private void Awake()
    {
        instance = this;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver(bool playerWon)
    {
        Time.timeScale = 0;

        if (playerWon)
        {
            headerText.text = "LEVEL CLEAR";
        }
        else
        {
            headerText.text = "GAME OVER";
        }

        mainText.text = "Shots: " + GameController.instance.shotsFired.ToString("00") + "\n";
        mainText.text += "Time: " + GameController.instance.timeTaken.ToString("0000") + "s";

        UITopBannerController.instance.Hide();
        Open(this.GetComponent<CanvasGroup>());
    }
}
