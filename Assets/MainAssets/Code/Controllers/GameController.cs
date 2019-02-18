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

    [HideInInspector]
    public bool gameIsPlaying;

    [HideInInspector]
    public int shotsFired, timeTaken;

    [SerializeField]
    public bool isTutorial;

    public int projSpeed;

    public LevelInfo currentLevel;


    private CameraShake[] cameraShakes;

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

        shotsFired = 0;
        timeTaken = 0;

        player = GameObject.FindGameObjectWithTag("Player");
        enemyRoster = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        cameraShakes = FindObjectsOfType<CameraShake>();

        gameIsPlaying = true;

        Time.timeScale = 1;

        StartCoroutine(Timer());
    }

    public void RemoveFromEnemyRoster(GameObject enemy)
    {
        enemyRoster.Remove(enemy);
    }

    public void Update()
    {
        if (enemyRoster.Count == 0 && gameOver == false && isTutorial == false)
        {
            gameOver = true;
            StartCoroutine(WinLevel());
        }
    }

    public void EnemiesRotate(float rotationAmount)
    {
        if (rotationAmount != 0)
        {
            foreach (GameObject enemy in enemyRoster)
            {
                enemy.GetComponent<EnemyMovement>().Rotate(rotationAmount);
                enemy.GetComponent<EnemyController>().Burst();
            }
        }
    }

    public void EnemiesShoot()
    {
        foreach(CameraShake cam in cameraShakes)
        {
            cam.shakeDuration = 0.5f;
        }

        foreach (EnemyShoot enemy in enemyRoster.SelectMany(x => x.GetComponentsInChildren<EnemyShoot>()))
        {
            enemy.Shoot();
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
        gameIsPlaying = false;
        yield return new WaitForSeconds(1.5f);
        UIGameoverController.instance.GameOver(player.GetComponent<PlayerController>().isDead == false);
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            UIPauseController.instance.PauseGame();
        }
    }
}
