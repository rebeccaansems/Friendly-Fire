using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverallController : MonoBehaviour
{
    public LevelInfo[] allLevels;
    public LevelInfo tutorialLevel;

    public int buildIndexVariance, levelSelectBuildIndex, tutorialBuildIndex;

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
}
