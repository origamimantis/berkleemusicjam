//Reese Lodwick
//11/6/2020
//Takes in a color and a prefab to be used in the level editor script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColorToPrefab
{
    public ColorToPrefab(Color c, GameObject prefab)
    {
        this.color = c;
        this.prefab = prefab;
    }

    public Color color;
    public GameObject prefab;
}
