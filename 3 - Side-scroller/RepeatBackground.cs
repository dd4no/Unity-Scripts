using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Background start position
    private Vector3 startPos;
    // Repeat position
    public float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        // Get background starting position
        startPos = transform.position;
        // Get half the width of background as a repeat point
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // If background position is less than repeat point
        if (transform.position.x < startPos.x - repeatWidth)
        {
            // Reset postion to start position
            transform.position = startPos;
        }
    }
}
