using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPauseController : UIController
{
    [SerializeField]
    private CanvasGroup[] contentPanels;

    [SerializeField]
    private Slider senseSlider, volumeSlider;

    [SerializeField]
    private Toggle invertToggle;

    private int currentContentPanel;

    public static UIPauseController instance;

    private void Awake()
    {
        instance = this;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;

        LoadSettings();

        Open(this.GetComponent<CanvasGroup>());
        OpenWithoutStack(contentPanels[currentContentPanel]);
    }

    public void PlayGame()
    {
        Time.timeScale = 1;

        Close(this.GetComponent<CanvasGroup>());

        SaveSettings();
    }

    public void ResetGame()
    {
        OverallController.instance.LoadLevel();
        UISceneTransition.instance.LoadScene();

        SaveSettings();
    }

    public void VolumeChanged()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        OverallController.instance.volume = volumeSlider.value;
    }

    public void Tweet()
    {
        string storeLink = "https://itunes.apple.com/us/app/hivemind-free-space-puzzle/id1109489072?ls=1&mt=8";
#if UNITY_ANDROID
        storeLink = "https://play.google.com/store/apps/details?id=com.rebeccaansems.hivemind";
#endif
        string shareText = "I've unlocked " + OverallController.instance.maxLevel + " levels on HiveMind, can you beat that? " + storeLink;

        Debug.Log(shareText);

        new NativeShare().SetText(shareText);
        new NativeShare().Share();
    }

    public void GotoLevelSelect()
    {
        UISceneTransition.instance.LoadScene(OverallController.instance.levelSelectBuildIndex);
        SaveSettings();
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
