using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particles;

    public void Start()
    {
        var emit = particles.emission;
        emit.SetBurst(0, new ParticleSystem.Burst(Random.Range(0.1f, 1.0f), 500));
    }

    public void Die()
    {
        this.GetComponent<Animator>().SetBool("isDead", true);
        GameController.instance.gameIsPlaying = false;
        
        particles.transform.parent = null;
        particles.Stop();
        Destroy(particles, 1);
        
        StartCoroutine(GameOverScreen());
    }

    private IEnumerator GameOverScreen()
    {
        yield return new WaitForSeconds(1.5f);
        UIGameoverController.instance.GameOver(false);
        Destroy(this.gameObject);
    }
}
