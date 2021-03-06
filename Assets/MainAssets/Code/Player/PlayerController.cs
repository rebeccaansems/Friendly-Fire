﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public bool isDead;

    [SerializeField]
    private ParticleSystem particles, bursts, projectileShoot;

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
        if (particles != null)
        {
            bursts.Stop();
            bursts.Play();
        }
    }

    public void ShootEffectPlay()
    {
        this.GetComponent<Animator>().SetBool("isShooting", true);
        projectileShoot.Stop();
        projectileShoot.Play();
    }

    public void ShootEffectStop()
    {
        this.GetComponent<Animator>().SetBool("isShooting", false);
    }
    
    public void Die()
    {
        isDead = true;
        shipImage.enabled = false;

        this.GetComponent<Animator>().SetBool("isDead", true);
        GameController.instance.gameIsPlaying = false;

        this.GetComponent<PlayAudio>().PlayRandom();

        if (particles != null)
        {
            particles.transform.parent = null;
            particles.Stop(true);
            Destroy(particles.gameObject, 1);
        }

        StartCoroutine(GameOverScreen());
    }

    private IEnumerator GameOverScreen()
    {
        yield return new WaitForSeconds(1.5f);
        UIGameoverController.instance.GameOver(false);
        Destroy(this.gameObject);
    }
}
