using UnityEngine;

public class CameraGyro : MonoBehaviour
{
    void Update()
    {
        this.transform.Rotate(
            -Input.gyro.rotationRate.x * 0.05f, 
            -Input.gyro.rotationRate.y * 0.05f, 
            -Input.gyro.rotationRate.z * 0.05f);

        transform.eulerAngles = new Vector3(
            Mathf.Clamp(transform.eulerAngles.x, -2, 2),
            Mathf.Clamp(transform.eulerAngles.y, -2, 2),
            Mathf.Clamp(transform.eulerAngles.z, -2, 2));
    }
}
