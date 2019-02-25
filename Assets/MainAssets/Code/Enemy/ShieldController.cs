using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [SerializeField]
    private Sprite[] shieldHealth;

    [SerializeField]
    private int health;

    private void Start()
    {
        this.transform.parent.GetComponent<EdgeCollider2D>().enabled = false;
    }

    public bool Damage()
    {
        Burst();
        this.GetComponent<PlayAudio>().PlayRandom();
        health--;

        if (health > -1)
        {
            this.GetComponent<SpriteRenderer>().sprite = shieldHealth[health];
        }
        else
        {
            this.transform.parent.GetComponent<EdgeCollider2D>().enabled = true;

            Destroy(this.GetComponent<Collider2D>());
            Destroy(this.GetComponent<SpriteRenderer>());
            Destroy(this.gameObject, 1f);
        }

        return (health > -2);
    }

    private void Burst()
    {
        this.GetComponentInChildren<ParticleSystem>().Stop();
        this.GetComponentInChildren<ParticleSystem>().Play();
    }
}
