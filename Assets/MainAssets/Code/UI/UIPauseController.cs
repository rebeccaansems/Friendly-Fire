using System.Collections;
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
        Open(contentPanels[currentContentPanel]);
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

    public void MainMenu()
    {

        SaveSettings();
    }

    private void LoadSettings()
    {
        senseSlider.value = PlayerPrefs.GetFloat("RotSpeed", 50);
    }

    private void SaveSettings()
    {
        PlayerPrefs.SetFloat("RotSpeed", senseSlider.value);
        GameController.instance.rotSpeed = senseSlider.value;
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
