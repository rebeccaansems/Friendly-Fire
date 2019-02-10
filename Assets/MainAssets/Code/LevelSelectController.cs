using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectController : MonoBehaviour
{
    public static LevelSelectController instance;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        OverallController.instance.showIntroLevelText = true;
    }
}
