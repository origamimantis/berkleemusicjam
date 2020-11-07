using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Brian Kiss
//11/7/2020
//Keeps track of what levels are unlocked, beating the prev level unlocks the next.

public class LevelManager : MonoBehaviour
{
    private bool isPlayable;
    private int currentLevel;

    public Button[] buttons;

    private void Start()
    {
        currentLevel = 1;

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i + 1 > currentLevel)
                buttons[i].interactable = false;
        }
    }

    /// <summary>
    /// Used in level scenes after player beats the level, updates level select screen.
    /// </summary>
    /// <param name="level"></param>
    public void HasBeatenLevel(int level)
    {
        if (currentLevel == level)
            currentLevel++;
    }
}
