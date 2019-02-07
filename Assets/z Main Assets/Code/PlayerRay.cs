using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    LineRenderer line;

    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        DrawLine();
    }

    void DrawLine()
    {
        line.SetPosition(0, this.transform.position);
        line.SetPosition(1, transform.up * 10 + transform.position);
    }
}
