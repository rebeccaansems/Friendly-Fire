using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public void Die()
    {
        this.GetComponent<Animator>().SetBool("isDead", true);
        GameController.instance.gameIsPlaying = false;

        StartCoroutine(GameOverScreen());
    }

    private IEnumerator GameOverScreen()
    {
        yield return new WaitForSeconds(1.5f);
        UIGameoverController.instance.GameOver(false);
        Destroy(this.gameObject);
    }
}
