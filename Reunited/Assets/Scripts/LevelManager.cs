using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Brian Kiss
//11/7/2020
//Keeps track of what levels are unlocked, beating the prev level unlocks the next.

public class LevelManager : MonoBehaviour
{
    private int currentLevel;
    public Button[] buttons;

    private void Start()
    {
        //Sets level to current level, or 1 if no levels played.
        currentLevel = PlayerPrefs.GetInt("Level", 1);

        //Used to lock all levels except the first
        //for (int i = 0; i < buttons.Length; i++)
        //{
        //    if (i + 1 > currentLevel)
        //    {
        //        buttons[i].interactable = false;
        //    }
        //}
    }

    /// <summary>
    /// Used in level scenes after player beats the level, updates level select screen.
    /// </summary>
    /// <param name="level"></param>
    public void HasBeatenLevel(int level)
    {
        if (currentLevel == level)
            currentLevel++;

        //Stores the level that the player gets to.
        PlayerPrefs.SetInt("Level", currentLevel);

        //Used to unlock levels as the player progresses.
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i + 1 <= currentLevel)
            {
                buttons[i].interactable = true;
            }
        }
    }
}
