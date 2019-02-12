using System.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private Stack<CanvasGroup> currentPanel;

    public void Open(CanvasGroup panel)
    {
        if (currentPanel == null)
        {
            currentPanel = new Stack<CanvasGroup>();
        }

        if (currentPanel.Count == 0 || currentPanel.Peek() != panel)
        {
            currentPanel.Push(panel);

            panel.alpha = 1;
            panel.blocksRaycasts = true;
            panel.interactable = true;
        }

        if (this.GetComponent<Animator>() != null)
        {
            this.GetComponent<Animator>().SetBool("animIn", true);
        }
    }

    public void OpenWithoutStack(CanvasGroup panel)
    {
        panel.alpha = 1;
        panel.blocksRaycasts = true;
        panel.interactable = true;
    }

    public void Close(CanvasGroup panel)
    {
        panel.alpha = 0;
        panel.blocksRaycasts = false;
        panel.interactable = false;

        if (currentPanel == null)
        {
            currentPanel = new Stack<CanvasGroup>();
        }

        if (this.GetComponent<Animator>() != null)
        {
            this.GetComponent<Animator>().SetBool("animIn", false);
        }

        currentPanel.Pop();
    }

    public void CloseWithoutStack(CanvasGroup panel)
    {
        panel.alpha = 0;
        panel.blocksRaycasts = false;
        panel.interactable = false;
    }
}
