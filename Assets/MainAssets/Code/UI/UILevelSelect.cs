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

    [SerializeField]
    private CanvasGroup[] contentPanels;

    private int currentWorld;


    public static UILevelSelect instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Show();
    }

    private void Update()
    {
        worldText.text = firstLevelsPerWorld[currentWorld].worldName;
    }

    public void Hide()
    {
        Close(this.GetComponent<CanvasGroup>());
    }

    public void Show()
    {
        OpenWithoutStack(contentPanels[currentWorld]);
        Open(this.GetComponent<CanvasGroup>());
    }

    public void Move(int direction)
    {
        currentWorld += direction;
        if (currentWorld > contentPanels.Length - 1)
        {
            currentWorld = 0;
        }
        else if (currentWorld < 0)
        {
            currentWorld = contentPanels.Length - 1;
        }

        foreach (CanvasGroup panel in contentPanels)
        {
            CloseWithoutStack(panel);
        }
        OpenWithoutStack(contentPanels[currentWorld]);
    }
}
