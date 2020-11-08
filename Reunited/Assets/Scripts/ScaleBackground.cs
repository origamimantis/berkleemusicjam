using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Brian Kiss
//11/7/2020
//Finds size of screen and scales background image to be slightly bigger than it (for animation).

public class ScaleBackground : MonoBehaviour
{
    private float width;
    private float height;

    private float buffer = 100f;

    public Image background;

    /// <summary>
    /// Gets width/height of screen, changes background image to fit.
    /// </summary>
    void Start()
    {
        width = Screen.width;
        height = Screen.height;

        background.rectTransform.sizeDelta = new Vector2(width + buffer, height + buffer);
    }
}
