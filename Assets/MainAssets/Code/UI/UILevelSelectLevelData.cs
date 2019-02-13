using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
    private Image lockedImage;

    [SerializeField]
    private Sprite emptyStar, filledStar;

    public void Start()
    {
        levelNumber.text = levelToLoad.levelNumber.ToString("00");
        DisplayStars();

        if (PlayerPrefs.GetInt("Stars" + (levelToLoad.buildIndex - 1), 0) == 0 && levelToLoad.buildIndex > 0)
        {
            LockLevel();
        }
    }

    private void LockLevel()
    {
        this.GetComponentInChildren<TextMeshProUGUI>().alpha = 0.5f;
        this.GetComponent<Button>().enabled = false;
        lockedImage.enabled = true;
    }

    public void LoadLevel()
    {
        OverallController.instance.currentLevel = levelToLoad.buildIndex;
        UISceneTransition.instance.LoadScene(levelToLoad.buildIndex + OverallController.instance.buildIndexVariance);
    }

    private void DisplayStars()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("Stars" + levelToLoad.buildIndex, 0); i++)
        {
            starImages[i].sprite = filledStar;
        }
    }
}
