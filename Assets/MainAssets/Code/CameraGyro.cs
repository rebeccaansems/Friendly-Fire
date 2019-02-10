using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGyro : MonoBehaviour
{
    void Update()
    {
        this.transform.Rotate(
            -Input.gyro.rotationRateUnbiased.x * 0.05f, 
            -Input.gyro.rotationRateUnbiased.y * 0.05f, 
            -Input.gyro.rotationRateUnbiased.z * 0.05f);

        transform.eulerAngles = new Vector3(
            Mathf.Clamp(transform.eulerAngles.x, -2, 2),
            Mathf.Clamp(transform.eulerAngles.y, -2, 2),
            Mathf.Clamp(transform.eulerAngles.z, -2, 2));
    }
}
