using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureControl : MonoBehaviour
{
    public float rotSpeed = 20;

    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
        Vector3 playerPos = GameController.instance.player.transform.position;

        GameController.instance.player.transform.Rotate(Vector3.forward, -rotX);
        GameController.instance.player.transform.Rotate(Vector3.forward, rotY);

        GameController.instance.EnemiesRotate(rotY - rotX);
    }
}
