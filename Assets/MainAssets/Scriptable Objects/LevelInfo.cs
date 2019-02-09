﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level Info", order = 2)]
public class LevelInfo : ScriptableObject
{
    public int worldNumber;

    public int levelNumber;
    public string levelName;

    public int[] starLevels;
}