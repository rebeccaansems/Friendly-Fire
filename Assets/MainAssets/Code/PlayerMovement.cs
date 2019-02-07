using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRubyShared;

public class PlayerMovement : MonoBehaviour
{
    public float rotateSpeed;

    private RotateGestureRecognizer rotationGesture = new RotateGestureRecognizer();

    private void Start()
    {
        FingersScript.Instance.AddGesture(rotationGesture);
        rotationGesture.StateUpdated += RotationGestureUpdated;
    }

    private void RotationGestureUpdated(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Began && !GestureIntersectsSprite(gesture, this.gameObject))
        {
            gesture.Reset();
        }
        else if (gesture.State == GestureRecognizerState.Executing)
        {
            float rotationAmount = rotationGesture.RotationRadiansDelta * Mathf.Rad2Deg * rotateSpeed;

            GameController.instance.RotateEnemies(rotationAmount);
            this.transform.Rotate(0.0f, 0.0f, rotationAmount);
        }
    }

    private bool GestureIntersectsSprite(GestureRecognizer g, GameObject obj)
    {
        Renderer r = obj.GetComponent<Renderer>();
        if (r == null)
        {
            return false;
        }
        Bounds b = r.bounds;
        Vector3 gesturePos = Camera.main.ScreenToWorldPoint(new Vector3(g.FocusX, g.FocusY, 0.0f));
        gesturePos.z = b.center.z;

        return b.Contains(gesturePos);
    }
}
