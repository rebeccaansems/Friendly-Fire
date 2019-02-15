using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettingsController : UIController
{
    [SerializeField]
    private CanvasGroup[] contentPanels;

    [SerializeField]
    private Slider senseSlider, volumeSlider;

    [SerializeField]
    private Toggle invertToggle;

    private int currentContentPanel;


    public static UISettingsController instance;

    private void Awake()
    {
        instance = this;
    }

    public void Hide()
    {
        UITopBannerController.instance.Show();
        SaveSettings();
        Close(this.GetComponent<CanvasGroup>());
    }

    public void Show()
    {
        OpenWithoutStack(contentPanels[currentContentPanel]);
        LoadSettings();
        Open(this.GetComponent<CanvasGroup>());
    }

    public void VolumeChanged()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        OverallController.instance.volume = volumeSlider.value;
    }

    private void LoadSettings()
    {
        senseSlider.value = PlayerPrefs.GetFloat("RotSpeed", 50);
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f);

        invertToggle.isOn = PlayerPrefs.GetInt("InvertControls", 1) == -1;
    }

    private void SaveSettings()
    {
        PlayerPrefs.SetFloat("RotSpeed", senseSlider.value);
        OverallController.instance.rotSpeed = senseSlider.value;

        PlayerPrefs.SetInt("InvertControls", invertToggle.isOn ? -1 : 1);
        OverallController.instance.invertControls = invertToggle.isOn ? -1 : 1;
    }

    public void Move(int direction)
    {
        currentContentPanel += direction;
        if (currentContentPanel > contentPanels.Length - 1)
        {
            currentContentPanel = 0;
        }
        else if (currentContentPanel < 0)
        {
            currentContentPanel = contentPanels.Length - 1;
        }

        foreach (CanvasGroup panel in contentPanels)
        {
            CloseWithoutStack(panel);
        }
        OpenWithoutStack(contentPanels[currentContentPanel]);
    }
}
