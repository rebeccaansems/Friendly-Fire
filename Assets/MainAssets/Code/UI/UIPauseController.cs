using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIPauseController : UIController
{
    [SerializeField]
    private Slider senseSlider;

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
        senseSlider.value = PlayerPrefs.GetFloat("RotSpeed", 100);
    }

    private void SaveSettings()
    {
        PlayerPrefs.SetFloat("RotSpeed", senseSlider.value);
        GameController.instance.rotSpeed = senseSlider.value;
    }
}
