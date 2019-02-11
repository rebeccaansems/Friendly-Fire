using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    public GameObject scalableObjects;

    void Start()
    {
            float scale = (1.96933f * AspectRatio()) - 0.109479f;
            scalableObjects.transform.localScale = new Vector3(scale, scale, 1);
    }

    private float AspectRatio()
    {
        float screenWidth = Screen.width / Screen.dpi;
        float screenHeight = Screen.height / Screen.dpi;

        return screenWidth / screenHeight;
    }
}
