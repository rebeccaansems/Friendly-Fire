using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalAudio : MonoBehaviour
{
    void Update()
    {
        if (this.GetComponent<AudioSource>().volume != OverallController.instance.sfxVolume)
        {
            this.GetComponent<AudioSource>().volume = OverallController.instance.sfxVolume;
        }
    }
}
