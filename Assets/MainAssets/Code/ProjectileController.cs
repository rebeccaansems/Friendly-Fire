using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed;

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
        Die();
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

}
