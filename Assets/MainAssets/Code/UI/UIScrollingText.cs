using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScrollingText : MonoBehaviour
{
    public bool invisible;

    void Start()
    {
        invisible = false;
        this.GetComponent<TextMeshProUGUI>().text = GameController.instance.currentLevel.levelName;
    }
}
