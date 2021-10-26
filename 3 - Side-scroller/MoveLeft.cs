using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Scroll speed
    public float scrollSpeed = 20.0f;
    // Player controller script
    private PlayerController playerControllerScript;
    // Left game boundry
    private float leftBoundry = -10.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Get PlayerController script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // If game over condition is not met
        if (playerControllerScript.gameOver == false)
        {
            // Scroll object left
            transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        }

        // If obstacle hits left game boundry
        if (transform.position.x < leftBoundry && gameObject.CompareTag("Obstacle"))
        {
            // Destroy obstacle
            Destroy(gameObject);
        }
    }
}
