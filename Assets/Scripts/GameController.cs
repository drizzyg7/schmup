using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject[] enemies;
    public float timeBetweenSpawnLow = 0.5f;
    public float timeBetweenSpawnHigh = 3f;

    float spawnCools;
    Vector2 bounds;
    Vector3 spawnPosition;

    public Text scoreText;
    int scores = 0;

    // Start is called before the first frame update
    void Start()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        spawnCools = Random.Range(timeBetweenSpawnLow, timeBetweenSpawnHigh);
        scoreText.text = "Scores: " + scores.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCools > 0)
            spawnCools -= Time.deltaTime;
        else
            SpawnEnemy();

        scoreText.text = "Scores: " + scores.ToString();
    }


    void SpawnEnemy()
    {
        spawnPosition = new Vector3(Random.Range(-bounds.x + 1f, bounds.x - 1f), bounds.y + Random.Range(0.25f, 3f), 0f);
        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition, Quaternion.Euler(0,0,100));
        spawnCools = Random.Range(timeBetweenSpawnLow, timeBetweenSpawnHigh);
    }

    public void AddScore(int amount)
    {
        scores += amount;
    }
}
