using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPauseController : UIController
{
    public static UIPauseController instance;

    private void Awake()
    {
        instance = this;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;

        Open(this.GetComponent<CanvasGroup>());
        UITopBannerController.instance.Hide();
    }

    public void PlayGame()
    {
        Time.timeScale = 1;

        Close(this.GetComponent<CanvasGroup>());
        UITopBannerController.instance.Show();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Tweet()
    {
        Debug.Log("Tweet");
    }

    public void MainMenu()
    {

    }
}
