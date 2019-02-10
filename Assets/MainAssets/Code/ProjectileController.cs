using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Vector3 originalPos;

    private void Start()
    {
        originalPos = this.transform.position;
    }

    private void FixedUpdate()
    {
        transform.up = this.GetComponent<Rigidbody2D>().velocity;
    }

    public void IgnoreCollider(Collider2D collider)
    {
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), collider);
    }

    private void OnBecameInvisible()
    {
        Die();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().Die();
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().Die();
        }

        if (collision.gameObject.tag != "Mirror")
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

}
