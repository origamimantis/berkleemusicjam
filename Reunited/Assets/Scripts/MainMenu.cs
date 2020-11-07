using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Brian Kiss
//11/6/2020
//Game menu. Navigates to quit, level select, and help.

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Takes in a level and loads in by buildIndex, current + the level.
    /// </summary>
    /// <param name="level">The desired level to play</param>
    public void PlayGame(int level)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + level);
    }

    /// <summary>
    /// Quits the game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
