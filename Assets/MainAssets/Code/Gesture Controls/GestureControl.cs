using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureControl : MonoBehaviour
{
    public float rotSpeed = 20;

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            float rotX = 0, rotY = 0;

            if (Input.touchCount > 0)
            {
                rotX = Input.touches[0].deltaPosition.x;
                rotY = Input.touches[0].deltaPosition.y;
            }

            if (Input.GetMouseButton(0))
            {
                rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
                rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
            }
            
            Vector3 playerPos = GameController.instance.player.transform.position;

            GameController.instance.player.transform.Rotate(Vector3.forward, -rotX);
            GameController.instance.player.transform.Rotate(Vector3.forward, rotY);

            GameController.instance.EnemiesRotate(rotY - rotX);
        }
    }
}
