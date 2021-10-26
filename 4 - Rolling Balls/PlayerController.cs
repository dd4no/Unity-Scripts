using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Objects
    private Rigidbody playerBody;
    private GameObject focalPoint;
    public GameObject powerUpIndicator;
    // Movement rate
    public float speed = 5.0f;
    // Powerup variables
    public bool poweredUp = false;
    public float powerUpStrength = 15.0f;

    
    // Start is called before the first frame update
    void Start()
    {
        // Load player
        playerBody = GetComponent<Rigidbody>();
        // Load focal point
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        // User input
        float forwardInput = Input.GetAxis("Vertical");
        // Move forward and backwards with up and down arrows
        playerBody.AddForce(focalPoint.transform.forward * forwardInput * speed);
        // Lower position of powerup indicator on player object
        powerUpIndicator.transform.position = transform.position + new Vector3(0,-0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        // If player collides with powerup
        if (other.CompareTag("Powerup"))
        {
            // Indicate powerup state
            poweredUp = true;
            // Activate visual indicator
            powerUpIndicator.gameObject.SetActive(true);
            // Destroy powerup
            Destroy(other.gameObject);
            // Begin countdown
            StartCoroutine(PowerUpCountdown());
        }
    }

    IEnumerator PowerUpCountdown()
    {
        // Countdown timer
        yield return new WaitForSeconds(7);
        // Change powerup state when timer expires
        poweredUp = false;
        // De-activate visual indicator
        powerUpIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If player collides with enemy
        if (collision.gameObject.CompareTag("Enemy") && poweredUp)
        {
            // Log event
            Debug.Log("Collided with: " + collision.gameObject.name + " with power up set to " + poweredUp);
            // Load enemy rigidbody component
            Rigidbody enemyBody = collision.gameObject.GetComponent<Rigidbody>();
            // Set deflection
            Vector3 deflection = collision.gameObject.transform.position - transform.position;
            // Apply deflection force to repel enemy
            enemyBody.AddForce(deflection * powerUpStrength, ForceMode.Impulse);
        }
    }
}
