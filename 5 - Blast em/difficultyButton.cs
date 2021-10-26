using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class difficultyButton : MonoBehaviour
{
    // Button
    public Button button;
    // Game Manager
    private GameManager gameManager;
    // Difficulty Setting
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        // Get Button
        button = GetComponent<Button>();
        // Get Game Manager script
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        // Listen for mouse cick and set difficulty level
        button.onClick.AddListener(SetDifficulty);
    }

    // Set difficulty level
    void SetDifficulty()
    {
        // Start game with difficulty level of button clicked
        gameManager.StartGame(difficulty);
    }
}
