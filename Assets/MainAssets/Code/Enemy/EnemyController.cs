using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public void Die()
    {
        GameController.instance.RemoveFromEnemyRoster(this.gameObject);
        this.GetComponent<Animator>().SetBool("isDead", true);
        Destroy(this.gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
}
