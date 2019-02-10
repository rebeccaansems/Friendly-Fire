using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGyro : MonoBehaviour
{
    void Update()
    {
        this.transform.Rotate(
            -Input.gyro.rotationRateUnbiased.x, 
            -Input.gyro.rotationRateUnbiased.y, 
            -Input.gyro.rotationRateUnbiased.z);

        transform.eulerAngles = new Vector3(
            Mathf.Clamp(transform.eulerAngles.x, -2, 2),
            Mathf.Clamp(transform.eulerAngles.y, -2, 2),
            Mathf.Clamp(transform.eulerAngles.z, -2, 2));
    }
}
