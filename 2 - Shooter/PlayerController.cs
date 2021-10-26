using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement input value
    public float horizontalInput;
    // Movement rate
    public float movementRate = 10.0f;
    // Movement Boundries Left and Right
    public float xRange = 10.0f;
    // Projectile object
    public GameObject projectilePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If object exceeds left boundry...
        if (transform.position.x < -xRange)
        {
            // ... freeze left movement
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        // If object exceeds right boundry...
        if (transform.position.x > xRange)
        {
            // ... freeze right movement
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        // Get player input
        horizontalInput = Input.GetAxis("Horizontal");
        // Move object left or right as calculated from input
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * movementRate);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch projectile
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
