using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D level;
    public ColorToPrefab[] colorMappings;
    void Start()
    {
        GenerateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
        //Get the color of the pixel
        Color color = level.GetPixel(x, y);

        //Check if the pixel isn't colored and if not stop the method
        if(color.a == 0)
        {
            return;
        }

        foreach(ColorToPrefab colorMapping in colorMappings)
        {
            if(colorMapping.color.Equals(color))
            {
                Vector2 position = new Vector2(x, y);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
}
