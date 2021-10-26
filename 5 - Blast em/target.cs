using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    // Rigidbody
    private Rigidbody targetBody;
    // Game Manager
    private GameManager gameManager;

    // Force Range
    private float minForce = 12.0f;
    private float maxForce = 16.0f;
    // Maximum Torque 
    private float maxTorque = 10.0f;
    // Position Range
    private float xRange = 4.0f;
    private float ySpawn = -2.0f;

    // Explosions
    public ParticleSystem explosion;
    // Target point value
    public int pointValue;

    // Generate random force
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    // Generate random torque
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    // Generate random spawn position
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawn);
    }


    // Start is called before the first frame update
    void Start()
    {
        // Get Rigidbody
        targetBody = GetComponent<Rigidbody>();
        // Get Game Manger script
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // Set random starting position
        transform.position = RandomSpawnPos();
        // Launch target upwards with random amount of force
        targetBody.AddForce(RandomForce(), ForceMode.Impulse);
        // Add random torque to apply rotation
        targetBody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
    }

    // Destroy targets with mouse click
    private void OnMouseDown()
    {
        // If game not over
        if (!gameManager.gameOver)
        {
            // Destroy target
            Destroy(gameObject);
            // Display explosion particles
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            // Award points based on target value
            gameManager.UpdateScore(pointValue);
        }
    }

    // Detect and destroy targets falling below sensor line
    private void OnTriggerEnter(Collider other)
    {
        // Destroy target
        Destroy(gameObject);
        // If target is not "Bad" and player has lives remaining
        if (!gameObject.CompareTag("Bad") && gameManager.lives > 0)
        {
            // Use life
            gameManager.UseLife();
        }
    }

}
