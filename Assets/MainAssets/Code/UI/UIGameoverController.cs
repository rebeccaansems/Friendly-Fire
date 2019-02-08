using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameoverController : UIController
{
    [SerializeField]
    private TextMeshProUGUI mainText, headerText;

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

        DisplayStars();

        UITopBannerController.instance.Hide();
        Open(this.GetComponent<CanvasGroup>());
    }

    private void DisplayStars()
    {
        int[] starLevels = GameController.instance.currentLevel.starLevels;

        if (GameController.instance.shotsFired <= starLevels[0])
        {
            Debug.Log("3");
        }
        else if (IsBetween(GameController.instance.shotsFired, starLevels[0], starLevels[1]))
        {
            Debug.Log("2");
        }
        else if (IsBetween(GameController.instance.shotsFired, starLevels[1], starLevels[2]))
        {
            Debug.Log("1");
        }
        else
        {
            Debug.Log("0");
        }
    }

    private bool IsBetween(int numberToCheck, int bottom, int top)
    {
        return (numberToCheck >= bottom && numberToCheck <= top);
    }
}
