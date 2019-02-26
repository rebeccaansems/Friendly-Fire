using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILevelSelect : UIController
{
    [SerializeField]
    private TextMeshProUGUI worldText;

    [SerializeField]
    private LevelInfo[] firstLevelsPerWorld;

    [SerializeField]
    private CanvasGroup[] contentPanels;

    [SerializeField]
    private Image[] dotImages;

    [SerializeField]
    private Sprite emptyDotImage, filledDotImage;

    private int currentWorld;


    public static UILevelSelect instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentWorld = OverallController.instance.currentLevelSelectScreen;
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

        foreach (Image image in dotImages)
        {
            image.sprite = emptyDotImage;
        }
        dotImages[currentWorld].sprite = filledDotImage;

        foreach (CanvasGroup panel in contentPanels)
        {
            CloseWithoutStack(panel);
        }
        OpenWithoutStack(contentPanels[currentWorld]);
    }
}
