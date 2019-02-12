using DigitalRubyShared;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectile;

    private TapGestureRecognizer doubleTapGesture = new TapGestureRecognizer();

    void Start()
    {
        CreateDoubleTapGesture();
    }

    private void Shoot()
    {
        if (GameController.instance.gameIsPlaying)
        {
            GameController.instance.shotsFired++;
            GameController.instance.EnemiesShoot();

            Vector3 startPos = transform.position + new Vector3(0, 0, 0.1f);

            GameObject newProj = Instantiate(projectile, startPos, transform.rotation);
            GameController.instance.player.GetComponent<PlayerController>().ShootEffectPlay();

            if (GameController.instance.isTutorial)
            {
                newProj.GetComponent<Rigidbody2D>().velocity =
                    (this.GetComponent<LineController>().GetLineStopPosition() - transform.position).normalized * (GameController.instance.projectileSpeed / 3);
            }
            else
            {
                newProj.GetComponent<Rigidbody2D>().velocity =
                    (this.GetComponent<LineController>().GetLineStopPosition() - transform.position).normalized * GameController.instance.projectileSpeed;
            }
        }
    }

    private void DoubleTapGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Ended)
        {
            Shoot();
        }
    }

    private void CreateDoubleTapGesture()
    {
        doubleTapGesture = new TapGestureRecognizer();
        doubleTapGesture.NumberOfTapsRequired = 2;
        doubleTapGesture.StateUpdated += DoubleTapGestureCallback;
        FingersScript.Instance.AddGesture(doubleTapGesture);
    }
}
