using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureControl : MonoBehaviour
{

    private void Update()
    {
        if (Time.timeScale != 0 && GameController.instance.playersAreInteractable)
        {
            int invertRotation = OverallController.instance.invertControls;

            float rotSpeed = OverallController.instance.rotSpeed;
            float localRotSpeed = rotSpeed;
            float rotX = 0, rotY = 0;

#if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                localRotSpeed *= 12;

                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 10;

                if (GameController.instance.player.transform.position.y > Camera.main.ScreenToWorldPoint(mousePos).y)
                {
                    rotX = -Input.GetAxis("Mouse X") * localRotSpeed * Mathf.Deg2Rad;
                }
                else
                {
                    rotX = Input.GetAxis("Mouse X") * localRotSpeed * Mathf.Deg2Rad;
                }

                if (GameController.instance.player.transform.position.x > Camera.main.ScreenToWorldPoint(mousePos).x)
                {
                    rotY = -Input.GetAxis("Mouse Y") * localRotSpeed * Mathf.Deg2Rad;
                }
                else
                {
                    rotY = Input.GetAxis("Mouse Y") * localRotSpeed * Mathf.Deg2Rad;
                }
            }
#else
            if (Input.touchCount > 0)
            {
                Vector3 touchPos = Input.GetTouch(0).position;
                touchPos.z = 10;

                if (GameController.instance.player.transform.position.y > Camera.main.ScreenToWorldPoint(touchPos).y)
                {
                    rotX = -Input.touches[0].deltaPosition.x * localRotSpeed * Mathf.Deg2Rad;
                }
                else
                {
                    rotX = Input.touches[0].deltaPosition.x * localRotSpeed * Mathf.Deg2Rad;
                }

                if (GameController.instance.player.transform.position.x > Camera.main.ScreenToWorldPoint(touchPos).x)
                {
                    rotY = -Input.touches[0].deltaPosition.y * localRotSpeed * Mathf.Deg2Rad;
                }
                else
                {
                    rotY = Input.touches[0].deltaPosition.y * localRotSpeed * Mathf.Deg2Rad;
                }
            }
#endif
            Vector3 playerPos = GameController.instance.player.transform.position;

            float rotation = (invertRotation * rotY) - (invertRotation* rotX);
            GameController.instance.player.transform.Rotate(Vector3.forward, rotation);

            GameController.instance.EnemiesRotate(rotation);
        }
    }
}
