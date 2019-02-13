using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneTransition : MonoBehaviour
{
    public static UISceneTransition instance;

    public void Awake()
    {
        instance = this;
        this.GetComponent<CanvasGroup>().alpha = 1;
    }



    public void LoadScene()
    {
        StartCoroutine(LoadSceneDelayed(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadScene(int buildIndex)
    {
        StartCoroutine(LoadSceneDelayed(buildIndex));
    }

    public void LoadScene(string name)
    {
        StartCoroutine(LoadSceneDelayed(SceneManager.GetSceneByName(name).buildIndex));
    }

    IEnumerator LoadSceneDelayed(int buildIndex)
    {
        this.GetComponent<Animator>().SetBool("transOut", true);

        yield return new WaitForSecondsRealtime(0.5f);
        yield return SceneManager.LoadSceneAsync(buildIndex);
    }
}
