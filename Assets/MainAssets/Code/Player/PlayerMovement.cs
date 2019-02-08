using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRubyShared;

public class PlayerMovement : MonoBehaviour
{
    public float rotateSpeed;

    private RotateGestureRecognizer rotateGesture;

    private void Start()
    {
        CreateRotateGesture();
    }

    private void CreateRotateGesture()
    {
        rotateGesture = new RotateGestureRecognizer();
        rotateGesture.StateUpdated += RotateGestureCallback;
        FingersScript.Instance.AddGesture(rotateGesture);
    }

    private void RotateGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Executing)
        {
            float rotationAmount = rotateGesture.RotationRadiansDelta * Mathf.Rad2Deg * rotateSpeed;

            this.transform.Rotate(0.0f, 0.0f, rotationAmount);
        }
    }
}
