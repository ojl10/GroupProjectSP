using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script is used to operate the Pause Menu of the game

public class PauseMenu1 : MonoBehaviour {

    public static bool GameIsPaused = false; // bool allows for two types of instance True/False

    public GameObject pauseMenuUI; // Calls an object for the UI to be attached to
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) // The ESCAPE key is used here but can be switched out
        {
            if (GameIsPaused)
            {
                Resume(); // If the game is PAUSED the the game will be resumed
            } else
            {
                Pause(); // If the game is running the the game will be PAUSED
            }
        }
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // When the game is PAUSED and the button is pressed
        Time.timeScale = 1f; // The game is set to 1 (normal) speed
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true); // When the game is being played and the button is pressed
        Time.timeScale = 0f; // The game is set to 0 (no) speed
        GameIsPaused = true;
    }
}
