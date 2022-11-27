using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float score;
    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        score = 0;
    }

    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            if (playerControllerScript.sprintMode)
            {
                score += 2;
            }
            else
            {
                score++;
            }

            Debug.Log("Score: " + score);

        }

    }
}
