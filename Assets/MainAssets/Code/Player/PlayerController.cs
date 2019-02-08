using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public void Die()
    {
        this.GetComponent<Animator>().SetBool("isDead", true);
        StartCoroutine(DestroyOnAnimationFinish());

        StartCoroutine(GameOverScreen());
    }

    private IEnumerator DestroyOnAnimationFinish()
    {
        yield return new WaitForSeconds(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(this.gameObject);
    }

    private IEnumerator GameOverScreen()
    {
        yield return new WaitForSeconds(1.5f);
        UIGameoverController.instance.GameOver(false);
    }
}
