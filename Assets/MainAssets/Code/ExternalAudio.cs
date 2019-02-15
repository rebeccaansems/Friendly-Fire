using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalAudio : MonoBehaviour
{
    void Update()
    {
        if (this.GetComponent<AudioSource>().volume != OverallController.instance.volume)
        {
            this.GetComponent<AudioSource>().volume = OverallController.instance.volume;
        }
    }
}
