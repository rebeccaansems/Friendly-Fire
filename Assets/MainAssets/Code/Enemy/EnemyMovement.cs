using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public void Rotate(float rotation)
    {
        this.transform.Rotate(0.0f, 0.0f, rotation);
    }
}
