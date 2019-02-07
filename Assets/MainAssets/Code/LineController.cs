using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public RaycastHit2D[] raycastHits;

    private LineRenderer line;
    private LayerMask ignoredLayers;

    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        ignoredLayers = 1 << LayerMask.NameToLayer("Projectile Player") & 1 << LayerMask.NameToLayer("Projectile Enemy");
    }

    private void Update()
    {
        DrawLine();
    }

    void DrawLine()
    {
        line.SetPosition(0, this.transform.position);

        raycastHits = Physics2D.RaycastAll(transform.position, transform.up, 10, ignoredLayers);
        
        if (raycastHits.Length > 1)
        {
            line.SetPosition(1, raycastHits[1].point);
        }
        else
        {
            line.SetPosition(1, transform.up * 10 + transform.position);
        }
    }

    public Vector3 GetLineStopPosition()
    {
        if (raycastHits.Length > 1)
        {
            return raycastHits[1].point;
        }
        return transform.up * 10 + transform.position;
    }
}
