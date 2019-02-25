using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleController : MonoBehaviour
{
    public Vector2 delayLengthSec;

    private int sparkleDelay, count;

    void Start()
    {
        sparkleDelay = (int)Random.Range(delayLengthSec.x, delayLengthSec.y) * 60;
    }

    void Update()
    {
        count++;
        if (count > sparkleDelay)
        {
            int edge = Random.Range(0, 4);
            Vector2 sparklePos = new Vector2();

            if (edge == 0)
            {
                sparklePos = new Vector2(Random.Range(-1, 1), 0.25f);
            }
            else if (edge == 1)
            {
                sparklePos = new Vector2(Random.Range(-1, 1), -0.25f);
            }
            else if (edge == 2)
            {
                sparklePos = new Vector2(1, Random.Range(-0.25f, 0.25f));
            }
            else if (edge == 3)
            {
                sparklePos = new Vector2(-1, Random.Range(-0.25f, 0.25f));
            }

            this.transform.localPosition = sparklePos;
            sparkleDelay = (int)Random.Range(delayLengthSec.x, delayLengthSec.y) * 60;
            count = 0;

            this.GetComponent<Animator>().SetBool("sparkle", true);
        }

        if (count == sparkleDelay / 2)
        {
            this.GetComponent<Animator>().SetBool("sparkle", false);
        }
    }
}
