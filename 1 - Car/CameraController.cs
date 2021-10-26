using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Get player object
    public GameObject player;

    // Create offset
    private Vector3 offset = new Vector3(0, 7, -9);
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Offset camera position
        transform.position = player.transform.position + offset;
    }
}
