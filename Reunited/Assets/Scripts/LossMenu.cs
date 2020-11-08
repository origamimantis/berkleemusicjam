using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LossMenu : MonoBehaviour
{
    //static bool for use in other classes.
    public GameObject lossMenuUI;

    /// <summary>
    /// Turns loss menu on, stops game.
    /// </summary>
    public void LossScreen()
    {
        lossMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Resets game
    /// </summary>
    public void ResetScene()
    {
        lossMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Loads menu from pause screen, resets timeScale.
    /// </summary>
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
