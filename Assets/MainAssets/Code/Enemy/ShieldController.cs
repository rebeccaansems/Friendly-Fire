using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [SerializeField]
    private Sprite[] shieldHealth;

    [SerializeField]
    private int health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Contains("Projectile"))
        {
            health--;

            if (health > -1)
            {
                this.GetComponent<SpriteRenderer>().sprite = shieldHealth[health];
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
