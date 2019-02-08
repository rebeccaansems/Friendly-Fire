using System.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private CanvasGroup currentPanel;

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
        foreach (CanvasGroup panel in GameObject.FindGameObjectsWithTag("UI Panel").Select(x => x.GetComponent<CanvasGroup>()))
        {
            Close(panel);
        }

        currentPanel = null;
    }
}
