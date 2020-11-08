//Reese Lodwick
//11/6/2020
//Level editor that'll take images and determined by
//color and position of the pixel will place it in the unity project
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D level;

    /**
     * wall: black
     */
    public ColorToPrefab[] colorMappings;

    void Start()
    {
        GenerateLevel();
    }

    // Update is called once per frame
    void Update()
    {
    }
    //Goes through each pixel passed through colormapping
    void GenerateLevel()
    {
        for(int x = 0; x < level.width; x++)
        {
            for(int y = 0; y < level.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile(int x, int y)
    {
        Color levelColor;   
        GameObject line;
        //Get the color of the pixel
        levelColor = level.GetPixel(x, y);            
        if (levelColor.a == 0)
        {
            return;
        }
        for (int z = 0; z < colorMappings.Length; z++)
        {
            if (colorMappings[z].color.r == levelColor.r && colorMappings[z].color.b == levelColor.b && colorMappings[z].color.g == levelColor.g)
            { 
                    Vector2 position = new Vector2(x, y);
                    Instantiate(colorMappings[z].prefab, position, Quaternion.identity, transform);
            }
        }

    }
        //Check if the pixel isn't colored and if not stop the method
        

        //Sets the position to the position of the object in unity
        
}

