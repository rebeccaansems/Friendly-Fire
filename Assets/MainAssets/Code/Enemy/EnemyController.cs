using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particles, bursts;

    public void Start()
    {
        if (particles != null)
        {
            var emit = particles.emission;
            emit.SetBurst(0, new ParticleSystem.Burst(Random.Range(0.1f, 1.0f), 500));
        }
    }

    public void Burst()
    {
        if (particles != null)
        {
            bursts.Stop();
            bursts.Play();
        }
    }

    public void Die()
    {
        if (particles != null)
        {
            particles.transform.parent = null;
            particles.Stop();
            Destroy(particles.gameObject, 1);
        }

        GameController.instance.RemoveFromEnemyRoster(this.gameObject);
        this.GetComponent<Animator>().SetBool("isDead", true);
        Destroy(this.gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
}
