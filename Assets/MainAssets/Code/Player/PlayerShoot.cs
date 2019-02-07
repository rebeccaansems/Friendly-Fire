using DigitalRubyShared;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectile;

    private TapGestureRecognizer doubleTapGesture = new TapGestureRecognizer();

    // Start is called before the first frame update
    void Start()
    {
        CreateDoubleTapGesture();
    }

    private void Shoot()
    {
        GameController.instance.EnemiesShoot();

        GameObject newProj = Instantiate(projectile, transform.position, transform.rotation);
        newProj.GetComponent<Rigidbody2D>().velocity = 
            (this.GetComponent<LineController>().GetLineStopPosition() - transform.position).normalized * newProj.GetComponent<ProjectileController>().speed;
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
