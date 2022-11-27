using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform startPoint;
    public float walkSpeed;

    public static float score;
    private GameObject player;
    private PlayerController playerController;

    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        playerController.dirt.Stop();
        playerController.gameOver = true;
        score = 0;

        StartCoroutine(WalkIn());
    }

    void Update()
    {
        if (!playerController.gameOver)
        {
            if (playerController.sprintMode)
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


    IEnumerator WalkIn()
    {
        Vector3 start = playerController.transform.position;
        Vector3 end = startPoint.position;
        float length = Vector3.Distance(start, end);
        float startTime = Time.time;

        float covered = (Time.time - startTime) * walkSpeed;
        float completed = covered / length;

        playerController.GetComponent<Animator>().SetFloat("Sprint_f", 0.5f);

        while (completed < 1)
        {
            covered = (Time.time - startTime) * walkSpeed;
            completed = covered / length;
            playerController.transform.position = Vector3.Lerp(start, end, completed);
            yield return null;
        }

        playerController.GetComponent<Animator>().SetFloat("Sprint_f", 1.0f);
        //playerController.GetComponent<Animator>().SetTrigger("Run_trig");
        playerController.gameOver = false;


    }
}
