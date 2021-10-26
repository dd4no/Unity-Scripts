using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Movement rate
    public float speed = 3.0f;
    // Objects
    private GameObject player;
    private Rigidbody enemyBody;

    // Start is called before the first frame update
    void Start()
    {
        // Load Rigidbody component
        enemyBody = GetComponent<Rigidbody>();
        // Load player object
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Set attack direction toward player
        Vector3 attackDirection = (player.transform.position - transform.position).normalized;
        // Move enemy toward player
        enemyBody.AddForce( attackDirection * speed); 

        // If enemy falls over edge
        if (transform.position.y < -10)
        {
            // Destroy enemy
            Destroy(gameObject);
        }
    }
}
