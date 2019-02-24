using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStarController : MonoBehaviour
{
    public Vector2 delayLengthSec;

    private int starDelay, count, prevAnim;

    void Start()
    {
        starDelay = (int)Random.Range(delayLengthSec.x, delayLengthSec.y) * 60;
    }

    void Update()
    {
        count++;
        if (count > starDelay)
        {
            starDelay = (int)Random.Range(delayLengthSec.x, delayLengthSec.y) * 60;
            count = 0;

            int currAnim = Random.Range(0, 6);
            while (currAnim == prevAnim)
            {
                currAnim = Random.Range(0, 6);
            }
            prevAnim = currAnim;

            this.GetComponent<Animator>().SetInteger("starAnim", currAnim);
        }

        if (count == starDelay / 2)
        {
            this.GetComponent<Animator>().SetInteger("starAnim", -1);
        }
    }
}
