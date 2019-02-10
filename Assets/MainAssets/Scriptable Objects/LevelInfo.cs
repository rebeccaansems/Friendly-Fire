using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level Info", order = 2)]
public class LevelInfo : ScriptableObject
{
    public string worldName;
    public int buildIndex;

    public int levelNumber;
    public string levelName;

    public int[] starLevels;

    public void Update()
    {
        buildIndex = levelNumber - 1;
    }
}
