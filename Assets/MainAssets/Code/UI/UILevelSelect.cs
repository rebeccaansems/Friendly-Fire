using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILevelSelect : UIController
{
    [SerializeField]
    private TextMeshProUGUI worldText;

    [SerializeField]
    private LevelInfo[] firstLevelsPerWorld;

    private int currentWorld;

    public static UILevelSelect instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        worldText.text = firstLevelsPerWorld[currentWorld].worldName;

        Show();
    }

    public void Hide()
    {
        Close(this.GetComponent<CanvasGroup>());
    }

    public void Show()
    {
        Open(this.GetComponent<CanvasGroup>());
    }
}
