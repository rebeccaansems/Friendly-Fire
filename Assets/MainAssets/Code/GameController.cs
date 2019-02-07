using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector]
    public GameObject player;

    [HideInInspector]
    public List<GameObject> enemyRoster;

    public static GameController instance;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyRoster = GameObject.FindGameObjectsWithTag("Enemy").ToList();
    }

    public void RemoveFromEnemyRoster(GameObject enemy)
    {
        enemyRoster.Remove(enemy);
    }

    public void EnemiesRotate(float rotationAmount)
    {
        foreach (GameObject enemy in enemyRoster)
        {
            enemy.GetComponent<EnemyMovement>().Rotate(rotationAmount);
        }
    }

    public void EnemiesShoot()
    {
        foreach (GameObject enemy in enemyRoster)
        {
            enemy.GetComponentInChildren<EnemyShoot>().Shoot();
        }
    }
}
