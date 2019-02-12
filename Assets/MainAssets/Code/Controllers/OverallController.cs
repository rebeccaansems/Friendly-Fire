using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverallController : MonoBehaviour
{
    public LevelInfo[] allLevels;
    public LevelInfo tutorialLevel;

    public int buildIndexVariance;

    [HideInInspector]
    public int invertControls, currentLevel;

    [HideInInspector]
    public float volume, rotSpeed;

    public static OverallController instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            Setup();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Setup()
    {
        volume = PlayerPrefs.GetFloat("Volume", 0.5f);
        rotSpeed = PlayerPrefs.GetFloat("RotSpeed", 50);
        invertControls = PlayerPrefs.GetInt("InvertControls", 1);

        if (PlayerPrefs.GetInt("TutorialCompleted", 0) == 0)
        {
            SceneManager.LoadScene(tutorialLevel.buildIndex + buildIndexVariance - 1);
        }
    }
}
