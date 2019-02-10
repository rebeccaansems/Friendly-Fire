using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILevelSelectLevelData : MonoBehaviour
{
    [SerializeField]
    private LevelInfo levelToLoad;

    [SerializeField]
    private TextMeshProUGUI levelNumber;

    [SerializeField]
    private Image[] starImages;

    [SerializeField]
    private Sprite emptyStar, filledStar;

    public void Start()
    {
        levelNumber.text = levelToLoad.levelNumber.ToString("00");
        DisplayStars();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelToLoad.buildIndex + OverallController.instance.buildIndexVariance);
    }

    private void DisplayStars()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("Stars" + levelToLoad.buildIndex, 0); i++)
        {
            starImages[i].sprite = filledStar;
        }
    }
}
