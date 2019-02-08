using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public CanvasGroup gameoverCanvas;
    public List<CanvasGroup> allPanels;

    private CanvasGroup currentPanel;

    public static UIController instance;

    void Awake()
    {
        instance = this;
        CloseAll();
    }

    public void Open(CanvasGroup panel)
    {
        if (panel != currentPanel)
        {
            CloseAll();

            currentPanel = panel;

            panel.alpha = 1;
            panel.blocksRaycasts = true;
            panel.interactable = true;
        }
    }

    public void Close(CanvasGroup panel)
    {
        panel.alpha = 0;
        panel.blocksRaycasts = false;
        panel.interactable = false;
    }

    private void CloseAll()
    {
        foreach (CanvasGroup panel in allPanels)
        {
            Close(panel);
        }

        currentPanel = null;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
