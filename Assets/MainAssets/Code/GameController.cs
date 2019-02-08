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

    public int shotsFired, timeTaken;

    private bool gameOver;


    public static GameController instance;

    void Awake()
    {
        instance = this;
        Setup();
    }

    private void Setup()
    {
        gameOver = false;

        player = GameObject.FindGameObjectWithTag("Player");
        enemyRoster = GameObject.FindGameObjectsWithTag("Enemy").ToList();

        Time.timeScale = 1;

        StartCoroutine(Timer());
    }

    public void RemoveFromEnemyRoster(GameObject enemy)
    {
        enemyRoster.Remove(enemy);
    }

    public void Update()
    {
        if (enemyRoster.Count == 0)
        {
            StartCoroutine(WinLevel());
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

    private IEnumerator Timer()
    {
        while (Time.timeScale != 0)
        {
            yield return new WaitForSeconds(1.0f);
            timeTaken++;
        }
    }

    private IEnumerator WinLevel()
    {
        yield return new WaitForSeconds(1.5f);
        UIGameoverController.instance.GameOver();
    }
}
