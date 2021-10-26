using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Obstacle Prefab
    public GameObject obstaclePrefab;
    // Spawn position
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    // Spawn start delay
    private float startDelay = 2.0f;
    // Spawn rate
    private float repeatRate = 2.0f;
    // Player controller script
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        // Get PlayerController script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        // Spawn obstacles
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        // If game over condition is not met
        if (playerControllerScript.gameOver == false)
        {
            // Spawn obstacle
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
