using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Brian Kiss
//11/6/2020
//Brings up a pause menu when the user presses [esc].

public class PauseMenu : MonoBehaviour
{
    //static bool for use in other classes.
    public static bool paused = false;
    public GameObject pauseMenuUI;

    /// <summary>
    /// Checks if [esc] is pressed.
    /// </summary>
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
                Resume();
            else
                Pause();
        }
    }

    /// <summary>
    /// Turns pause menu off, resumes game.
    /// </summary>
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    /// <summary>
    /// Turns pause menu on, stops game.
    /// </summary>
    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    /// <summary>
    /// Loads menu from pause screen, resets timeScale.
    /// </summary>
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Quits the game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
