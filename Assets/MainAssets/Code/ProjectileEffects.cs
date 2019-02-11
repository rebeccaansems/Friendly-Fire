using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEffects : MonoBehaviour
{
    public void Die()
    {
        this.gameObject.transform.parent = null;
        this.GetComponent<ParticleSystem>().Stop();

        Destroy(this.gameObject, 1);
    }
}
