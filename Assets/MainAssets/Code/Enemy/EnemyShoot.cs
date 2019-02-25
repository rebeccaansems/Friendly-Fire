using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectile;

    [SerializeField]
    private Collider2D shield;

    public void Shoot()
    {
        if (this.transform.parent.GetComponent<Renderer>().enabled == true)
        {
            Vector3 startPos = transform.position + new Vector3(0, 0, 0.1f);

            GameObject newProj = Instantiate(projectile, startPos, transform.rotation);

            this.transform.parent.GetComponent<EnemyController>().ShootEffectPlay();

            this.GetComponent<PlayAudio>().PlayRandom();

            newProj.GetComponent<ProjectileController>().IgnoreCollider(transform.parent.GetComponent<Collider2D>(), shield);
            newProj.GetComponent<Rigidbody2D>().velocity =
                (this.GetComponent<LineController>().GetLineStopPosition() - transform.position).normalized * GameController.instance.projSpeed * Random.Range(0.990f, 1.100f);
        }
    }
}
