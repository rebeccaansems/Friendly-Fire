using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public void Die()
    {
        GameController.instance.RemoveFromEnemyRoster(this.gameObject);
        this.GetComponent<Animator>().SetBool("isDead", true);
        StartCoroutine(DestroyOnAnimationFinish());
    }

    private IEnumerator DestroyOnAnimationFinish()
    {
        yield return new WaitForSeconds(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(this.gameObject);
    }
}
