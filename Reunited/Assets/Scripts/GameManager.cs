using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Brian Kiss
//11/6/2020
//Manages switching between levels, spawning player in, sounds, music.

public class GameManager : MonoBehaviour
{
    //Current amount of levels in the game.
    int maxLevels = 5;

    /// <summary>
    /// Spawns the player at the correct location.
    /// </summary>
    public void SpawnPlayer()
    {

    }

    /// <summary>
    /// Switches between levels after completing one. Checks if it has run out of levels.
    /// </summary>
    public void SwitchLevels()
    {
        if((SceneManager.GetActiveScene().buildIndex + 1) <= maxLevels)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(0);  //else loads menu
    }
}
