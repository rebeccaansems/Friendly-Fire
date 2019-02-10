﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIPauseController : UIController
{
    [SerializeField]
    private CanvasGroup[] contentPanels;

    [SerializeField]
    private Slider senseSlider;

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
        UITopBannerController.instance.Hide();
    }

    public void PlayGame()
    {
        Time.timeScale = 1;

        Close(this.GetComponent<CanvasGroup>());
        UITopBannerController.instance.Show();

        SaveSettings();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        SaveSettings();
    }

    public void Tweet()
    {
        Debug.Log("Tweet");
    }

    public void GotoLevelSelect()
    {
        SceneManager.LoadScene("Level Select");

        SaveSettings();
    }

    private void LoadSettings()
    {
        senseSlider.value = PlayerPrefs.GetFloat("RotSpeed", 50);
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
