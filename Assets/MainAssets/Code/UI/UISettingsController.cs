using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VoxelBusters.NativePlugins;

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
        Time.timeScale = 1;
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

    public void Tweet()
    {
        SocialShareSheet _shareSheet = new SocialShareSheet();
        _shareSheet.Text = "I've unlocked " + OverallController.instance.maxLevel + " levels on HiveMind, can you beat that?";

        _shareSheet.URL = "https://itunes.apple.com/us/app/hivemind-free-space-puzzle/id1109489072?ls=1&mt=8";
#if UNITY_ANDROID
        _shareSheet.URL = "https://play.google.com/store/apps/details?id=com.rebeccaansems.hivemind";
#endif

        NPBinding.UI.SetPopoverPointAtLastTouchPosition(); // To show popover at last touch point on iOS. On Android, its ignored.
        NPBinding.Sharing.ShowView(_shareSheet, FinishedSharing);
    }

    private void FinishedSharing(eShareResult _result)
    {
        Debug.Log("I've unlocked " + OverallController.instance.maxLevel + " levels on HiveMind, can you beat that?");
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
