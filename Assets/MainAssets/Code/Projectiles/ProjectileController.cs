using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
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

    public void IgnoreCollider(Collider2D ship, Collider2D shield)
    {
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), ship, true);

        if (shield != null)
        {
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), shield, true);
        }

        StartCoroutine(ProjectileHasBeenShot(ship));
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
            animator.SetBool("isDead", true);
            Destroy(animator, 1);
        }

        particles.Die();

        Destroy(this.gameObject);
    }

    IEnumerator ProjectileHasBeenShot(Collider2D collider)
    {
        yield return new WaitForSeconds(0.1f);
        if (collider != null && this.GetComponent<Collider2D>() != null)
        {
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), collider, false);
        }
    }

}
