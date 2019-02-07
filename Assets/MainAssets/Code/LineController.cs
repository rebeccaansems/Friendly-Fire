using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer line;

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

        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, transform.up);
        
        if (hit.Length > 1)
        {
            line.SetPosition(1, hit[1].point);
        }
        else
        {
            line.SetPosition(1, transform.up * 10 + transform.position);
        }

    }
}
