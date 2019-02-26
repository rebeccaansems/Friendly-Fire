using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class OverallController : MonoBehaviour
{
    public LevelInfo[] allLevels;
    public LevelInfo tutorialLevel;

    public int buildIndexVariance, levelSelectBuildIndex, tutorialBuildIndex;

    [HideInInspector]
    public int invertControls, currentLevel, currentLevelSelectScreen, levelsPlayedSession, maxLevel = 36;

    [HideInInspector]
    public float volume, rotSpeed;

    private float timeOfLastAd;

    private bool levelChanged = false;

    public static OverallController instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        volume = PlayerPrefs.GetFloat("Volume", 0.5f);
        rotSpeed = PlayerPrefs.GetFloat("RotSpeed", 25);
        invertControls = PlayerPrefs.GetInt("InvertControls", 1);
    }

    public void LoadLevel()
    {
        levelsPlayedSession++;
        if (levelsPlayedSession > 5 && Time.realtimeSinceStartup - timeOfLastAd > 180)
        {
            timeOfLastAd = Time.realtimeSinceStartup;
            levelsPlayedSession = 0;
            Advertisement.Show();
        }
    }

    private void Update()
    {
        currentLevelSelectScreen = (int)(currentLevel / 6);
    }
}
