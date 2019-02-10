using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    public GameObject scalableObjects;

    void Start()
    {
        if (AspectRatio() < 0.6f)
        {
            scalableObjects.transform.position = new Vector3(scalableObjects.transform.position.x, scalableObjects.transform.position.y, (0.004f * Screen.width) - 4.5f);
            GameController.instance.projectileSpeed = (-0.09f * Screen.width) + 110;
        }
    }

    private float AspectRatio()
    {
        float screenWidth = Screen.width / Screen.dpi;
        float screenHeight = Screen.height / Screen.dpi;

        return screenWidth / screenHeight;
    }
}
