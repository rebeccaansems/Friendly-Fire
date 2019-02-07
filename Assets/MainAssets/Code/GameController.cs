using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector]
    public GameObject player;

    [HideInInspector]
    public GameObject[] enemies;

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
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void RotateEnemies(float rotationAmount)
    {
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyMovement>().Rotate(rotationAmount);
        }
    }
}
