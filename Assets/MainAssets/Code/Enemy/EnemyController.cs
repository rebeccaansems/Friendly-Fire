using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particles, bursts;

    [SerializeField]
    private ParticleSystem[] projectileShootingPS;

    [SerializeField]
    private SpriteRenderer shipImage;

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
        if (bursts != null)
        {
            bursts.Stop();
            bursts.Play();
        }
    }

    public void Die()
    {
        this.GetComponent<PlayAudio>().PlayRandom();
        shipImage.enabled = false;

        if (particles != null)
        {
            particles.transform.parent = null;
            particles.Stop();
            Destroy(particles.gameObject, 2);
        }

        GameController.instance.RemoveFromEnemyRoster(this.gameObject);
        this.GetComponent<Animator>().SetBool("isDead", true);

        Destroy(this.GetComponent<Collider2D>());
        Destroy(this.gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length * 2);
    }

    public void ShootEffectPlay()
    {
        this.GetComponent<Animator>().SetBool("isShooting", true);

        foreach (ParticleSystem part in projectileShootingPS)
        {
            part.Stop();
            part.Play();
        }
    }

    public void ShootEffectStop()
    {
        this.GetComponent<Animator>().SetBool("isShooting", false);
    }
}
