using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Top boundry
    private float topBoundry = 30;
    // Bottom boundry
    private float bottomBoundry = -10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // If object position exceeds top boundry
        if (transform.position.z > topBoundry)
        {
            // Remove game object
            Destroy(gameObject);
        }
        // Else if object position exceeds bottom Boundry
        else if (transform.position.z < bottomBoundry)
        {
            // Log end of game condition
            Debug.Log("Game Over!");
            // Remove game object
            Destroy(gameObject);
        }
    }
}
