﻿using System.Collections;
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
    public bool playersAreInteractable;

    public int shotsFired, timeTaken;

    public float projectileSpeed;

    public LevelInfo currentLevel;

    private bool gameOver;
    
    [SerializeField]
    private UIScrollingText scrollingText;


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

        Time.timeScale = 1;

        if (OverallController.instance.showIntroLevelText)
        {
            StartCoroutine(ShowScrollingText());
            scrollingText.GetComponent<Animator>().SetBool("showIntro", true);
            OverallController.instance.showIntroLevelText = false;
        }
        else
        {
            playersAreInteractable = true;
            StartCoroutine(Timer());
        }
    }

    public void RemoveFromEnemyRoster(GameObject enemy)
    {
        enemyRoster.Remove(enemy);
    }

    public void Update()
    {
        if (enemyRoster.Count == 0 && gameOver == false)
        {
            gameOver = true;
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
        UIGameoverController.instance.GameOver(true);
    }

    private IEnumerator ShowScrollingText()
    {
        playersAreInteractable = false;
        yield return new WaitForSeconds(0.45f * GameController.instance.currentLevel.levelName.ToString().Length);

        playersAreInteractable = true;
        StartCoroutine(Timer());
    }
}
