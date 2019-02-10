using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILevelSelect : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI worldText;

    [SerializeField]
    private LevelInfo[] firstLevelsPerWorld;

    private int currentWorld;

    private void Start()
    {
        worldText.text = firstLevelsPerWorld[currentWorld].worldName;
    }
}
