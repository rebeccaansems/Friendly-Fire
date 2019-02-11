using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("0-Red, 1-White")]
    private int color;

    [SerializeField]
    private ProjectileEffects particles;

    [SerializeField]
    private Animator animator;

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
        Die(false);
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
            Die(true);
        }
    }

    private void Die(bool onScreen)
    {
        if (onScreen)
        {
            animator.transform.parent = null;
            animator.SetInteger("color", color);
            animator.SetBool("isDead", true);
            Destroy(animator, 1);
        }

        particles.Die();

        Destroy(this.gameObject);
    }

}
