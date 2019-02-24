using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float scrollSpeed;

    private void Start()
    {
        this.transform.position = new Vector3(-12 * (GameController.instance.currentLevel.levelNumber % 6), 0, 0);

        for (int i = 0; i < GameController.instance.currentLevel.levelNumber % 6; i++)
        {
            this.transform.GetChild(i).GetComponent<ScrollingChunk>().ResetLocation();
        }
    }

    private void Update()
    {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x + (scrollSpeed * Time.deltaTime), 0, 0);
    }
}
