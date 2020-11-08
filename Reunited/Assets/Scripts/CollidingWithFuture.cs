using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Brian Kiss
//11/8/2020
//Placed on player, when colliding with future ends level, unlocks level in level select.

public class CollidingWithFuture : MonoBehaviour
{
    public LevelManager levelManager;
    public int amtOfLevels;

    private void Start()
    {
        levelManager = GetComponent<LevelManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Future")
        {
            //Ends level. Sends current level to levelManager to update level select screen.
            //Loads the next scene if there is one.
            if (SceneManager.GetActiveScene().buildIndex + 1 <= amtOfLevels)
            {
                levelManager.HasBeatenLevel(SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                //Completed all levels.
            }
        }
    }
}
