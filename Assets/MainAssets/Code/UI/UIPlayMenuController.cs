using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        if (PlayerPrefs.GetInt("TutorialCompleted", 0) == 0)
        {
            UISceneTransition.instance.LoadScene(OverallController.instance.tutorialBuildIndex);
        }
        else
        {
            UISceneTransition.instance.LoadScene(OverallController.instance.levelSelectBuildIndex);
        }
    }
}
