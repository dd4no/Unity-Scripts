using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Objects
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab; 
    // Spawn boundries
    private float spawnRange = 9.0f;
    // Number of enemies on field
    public int enemyCount;
    // Wave number
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn first wave of enemies
        SpawnEnemyWave(waveNumber);
        // Spawn initial powerup
        Instantiate(powerUpPrefab, randomCoord(), powerUpPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // Get number of enemies on field
        enemyCount = FindObjectsOfType<Enemy>().Length;

        // If enemy count is zero
        if (enemyCount == 0)
        {
            // Increment wave number
            waveNumber++;
            // Spawn new wave
            SpawnEnemyWave(waveNumber);
            // Spawn new powerup
            Instantiate(powerUpPrefab, randomCoord(), powerUpPrefab.transform.rotation);
        }
    }

    // Generate random field position
    private Vector3 randomCoord()
    {
        // Random X coordinate
        float spawnPositionX = Random.Range(-spawnRange,spawnRange);
        // Random Y coordinate
        float spawnPositionZ = Random.Range(-spawnRange,spawnRange);
        // Random position
        Vector3 randomPosition = new Vector3(spawnPositionX, 0, spawnPositionZ);
        return randomPosition;
    }

    // Generate enemy wave
    void SpawnEnemyWave(int numberOfEnemies)
    {
        // Spawn specified number of enemies
        for (int i=0; i<numberOfEnemies; i++)
        {
        Instantiate(enemyPrefab, randomCoord(), enemyPrefab.transform.rotation);
        }
    }
}


