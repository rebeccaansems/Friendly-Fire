using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed;

    public void Shoot()
    {
        Vector3 startPos = transform.position + new Vector3(0, 0, 5);

        GameObject newProj = Instantiate(projectile, startPos, transform.rotation);
        newProj.GetComponent<ProjectileController>().IgnoreCollider(transform.parent.GetComponent<Collider2D>());
        newProj.GetComponent<Rigidbody2D>().velocity =
            (this.GetComponent<LineController>().GetLineStopPosition() - transform.position).normalized * newProj.GetComponent<ProjectileController>().speed;
    }
}
