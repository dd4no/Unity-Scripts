using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Title Screen
    public GameObject titleScreen;

    // Score display
    public TextMeshProUGUI scoreText;
    // Score
    private int score;

    // Lives display
    public TextMeshProUGUI livesText;
    // Lives
    public int lives;

    // Pause screen
    public GameObject pauseScreen;
    public bool paused = false;

    // Game Over Screen
    public GameObject gameOverScreen;
    // Game Over display
    public TextMeshProUGUI gameOverText;
    // Restart button
    public Button resetButton;
    // Game Over status
    public bool gameOver;

    // List of targets
    public List<GameObject> targets;
    // Spawn rate
    private float spawnRate = 4.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            paused = !paused;
            PauseGame();
        }

    }

    // Start Game routine
    public void StartGame(int difficulty)
    {
        // Set Game Over status
        gameOver = false;
        // Set zero score
        score = 0;
        UpdateScore(0);
        // Restore lives
        lives = 3;
        livesText.text = "Lives:  " + lives;
        // Set dificulty from user input
        spawnRate -= difficulty;
        // Hide Title Screen
        titleScreen.gameObject.SetActive(false);
        // Start spawning targets
        StartCoroutine(SpawnTarget());


    }

    // Spawn target coroutine
    IEnumerator SpawnTarget()
    {
        // While game is not over and player has lives left
        while (!gameOver && lives > 0)
        {
            // Wait for specified time
            yield return new WaitForSeconds(spawnRate);
            // Generate a random list index
            int index = Random.Range(0, targets.Count);
            // Create obect at random list index
            Instantiate(targets[index]);
        }
    }

    // Track score and display on screen
    public void UpdateScore(int scoreChange)
    {
        // Add change to score
        score += scoreChange;
        // Display score
        scoreText.text = "Score:   " + score;
    }

    // Use life and check for game ending condition
    public void UseLife()
    {
        lives--;
        livesText.text = "Lives:  " + lives;
        if (lives == 0)
        {
            GameOver();
        }
    }

    // Game Over routine
    public void GameOver()
    {
        // Set Game Over status
        gameOver = true;
        // Stop spawning targets
        StopAllCoroutines();
        // Display Game Over screen
        gameOverScreen.gameObject.SetActive(true);
    }

    // Restart actions
    public void Restart()
    {
        // Reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame()
    {
        if (paused && !gameOver)
        {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }

    }  

}
