using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIGameoverController : UIController
{
    [SerializeField]
    private TextMeshProUGUI mainText, headerText;

    [SerializeField]
    private Image[] starImages;

    [SerializeField]
    private Sprite emptyStar, filledStar;

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

            DisplayStars();
        }
        else
        {
            headerText.text = "GAME OVER";

            DisplayEmptyStars();
        }

        mainText.text = "Shots: " + GameController.instance.shotsFired.ToString("00") + "\n";
        mainText.text += "Time: " + GameController.instance.timeTaken.ToString("0000") + "s";

        UITopBannerController.instance.Hide();
        Open(this.GetComponent<CanvasGroup>());
    }

    private void DisplayStars()
    {
        int[] starLevels = GameController.instance.currentLevel.starLevels;

        if (GameController.instance.shotsFired <= starLevels[0])
        {
            starImages[2].sprite = filledStar;
            starImages[1].sprite = filledStar;
            starImages[0].sprite = filledStar;
        }
        else if (IsBetween(GameController.instance.shotsFired, starLevels[0], starLevels[1]))
        {
            starImages[2].sprite = emptyStar;
            starImages[1].sprite = filledStar;
            starImages[0].sprite = filledStar;
        }
        else if (IsBetween(GameController.instance.shotsFired, starLevels[1], starLevels[2]))
        {
            starImages[2].sprite = emptyStar;
            starImages[1].sprite = emptyStar;
            starImages[0].sprite = filledStar;
        }
        else
        {
            DisplayEmptyStars();
        }
    }

    private void DisplayEmptyStars()
    {
        starImages[2].sprite = emptyStar;
        starImages[1].sprite = emptyStar;
        starImages[0].sprite = emptyStar;
    }

    private bool IsBetween(int numberToCheck, int bottom, int top)
    {
        return (numberToCheck >= bottom && numberToCheck <= top);
    }
}
