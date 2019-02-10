using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGyro : MonoBehaviour
{
    void Update()
    {
        this.transform.Rotate(Mathf.Clamp(-Input.gyro.rotationRateUnbiased.x, -5, 5), Mathf.Clamp(-Input.gyro.rotationRateUnbiased.y, -5, 5), Mathf.Clamp(-Input.gyro.rotationRateUnbiased.z, -5, 5));
    }
}
