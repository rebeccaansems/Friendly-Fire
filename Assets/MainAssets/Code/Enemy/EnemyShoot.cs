using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectile;

    public void Shoot()
    {
        Vector3 startPos = transform.position + new Vector3(0, 0, 0.1f);

        GameObject newProj = Instantiate(projectile, startPos, transform.rotation);
        newProj.GetComponent<ProjectileController>().IgnoreCollider(transform.parent.GetComponent<Collider2D>());
        newProj.GetComponent<Rigidbody2D>().velocity =
            (this.GetComponent<LineController>().GetLineStopPosition() - transform.position).normalized * GameController.instance.projectileSpeed;
    }
}
