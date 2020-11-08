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
    public ColorToPrefab[] colorMappings;

    public GameObject future;
    public GameObject player;

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
        Dictionary<GameObject, List<Vector2>> positions = new Dictionary<GameObject, List<Vector2>>();

        for (int y = 0; y < level.height; y++)
        {
            for(int x = 0; x < level.width; x++)
            {
                Color levelColor = level.GetPixel(x, y);
                if (levelColor.a != 0)
                {
                    for (int z = 0; z < colorMappings.Length; z++)
                    {
                        if (colorMappings[z].color.r == levelColor.r && colorMappings[z].color.b == levelColor.b && colorMappings[z].color.g == levelColor.g)
                        {
                            GameObject prefab = colorMappings[z].prefab;
                            Vector2 position = new Vector2(x, y);
                            if (!positions.ContainsKey(prefab))
                            {
                                positions[prefab] = new List<Vector2>();
                            }
                            positions[prefab].Add(position);
                        }
                    }
                }
            }
        }

        GenerateTiles(positions);
    }

    void GenerateTiles(Dictionary<GameObject, List<Vector2>> positions)
    {
        /*
        float lastX = -999;
        float lastY = -999;
        */
        Vector2 objPos = new Vector2(-1, -1), scale = new Vector2(0, 0);

        foreach(GameObject fab in positions.Keys)
        {
            for(int i = 0; i < positions[fab].Count; i++)
            {
                Vector2 pos = positions[fab][i];

                GameObject go = Instantiate(fab, new Vector3(pos.x, pos.y, 0), Quaternion.identity, transform);

                HiddenRenderer renderer = go.GetComponent<HiddenRenderer>();
                renderer.future = future;

                // messes w/ texture scaling and I dont have enough time to make a fix for it
                /*
                print(pos);

                if (objPos.x == -1)
                {
                    objPos = new Vector2(pos.x, pos.y);
                    scale = new Vector2(1, 1);
                }
                else
                {
                    if (pos.x == lastX + 1 && pos.y == lastY)
                    {
                        objPos.Set(objPos.x + 0.5f, objPos.y);
                        scale.Set(scale.x + 1, scale.y);
                    }
                    else
                    {
                        GameObject current = Instantiate(fab, new Vector3(objPos.x, objPos.y, 0), Quaternion.identity, transform);
                        current.transform.localScale = new Vector3(scale.x, scale.y, 1);

                        objPos.x = -1;
                        i--;
                    }
                }

                lastY = pos.y;
                lastX = pos.x;*/
            }

            /*
            if (objPos.x != -1)
            {
                GameObject current = Instantiate(fab, new Vector3(objPos.x, objPos.y, 0), Quaternion.identity, transform);
                current.transform.localScale = new Vector3(scale.x, scale.y, 1);
            }*/
        }

       

        // Instantiate(colorMappings[z].prefab, position, Quaternion.identity, transform);

    }
    //Check if the pixel isn't colored and if not stop the method


    //Sets the position to the position of the object in unity

}

