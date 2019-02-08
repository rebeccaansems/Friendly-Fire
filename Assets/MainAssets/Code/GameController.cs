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
        instance = this;
        Setup();
    }

    private void Setup()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyRoster = GameObject.FindGameObjectsWithTag("Enemy").ToList();
    }

    public void RemoveFromEnemyRoster(GameObject enemy)
    {
        enemyRoster.Remove(enemy);
    }

    public void Update()
    {
        if (enemyRoster.Count == 0)
        {
            UIController.instance.Open(UIController.instance.gameoverCanvas);
        }
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
