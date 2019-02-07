using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed;

    public void Shoot()
    {
        GameObject newProj = Instantiate(projectile, transform.position, transform.rotation);
        newProj.GetComponent<ProjectileController>().IgnoreCollider(transform.parent.GetComponent<Collider2D>());
        newProj.GetComponent<Rigidbody2D>().velocity =
            (this.GetComponent<LineController>().GetLineStopPosition() - transform.position).normalized * newProj.GetComponent<ProjectileController>().speed;
    }
}
