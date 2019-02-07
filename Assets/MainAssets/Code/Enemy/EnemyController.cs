using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public void Die()
    {
        GameController.instance.RemoveFromEnemyRoster(this.gameObject);
        Destroy(this.gameObject);
    }
}
