using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingChunk : MonoBehaviour
{
    [HideInInspector]
    public int resets;

    private Vector2 startingLocation;
    private bool hasBeenVisible = false;

    private void Start()
    {
        startingLocation = this.transform.position;
        if (resets == 0)
        {
            resets = 1;
        }
    }

    private void OnBecameVisible()
    {
        hasBeenVisible = true;
    }

    private void OnBecameInvisible()
    {
        if (hasBeenVisible)
        {
            ResetLocation();
        }
    }

    public void ResetLocation()
    {
        GameObject newBackgroundChunk = Instantiate(this.gameObject, this.transform.parent);
        newBackgroundChunk.transform.localPosition = startingLocation + new Vector2(resets * 12 * 6, 0);
        newBackgroundChunk.GetComponent<ScrollingChunk>().resets = resets + 1;
        Destroy(this.gameObject);
    }
}
