using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPressurePlate : PressurePlate
{
    public GameObject[] openDoors;
    public GameObject[] closeDoors;
    
    public override void onStep()
    {
        foreach (var item in openDoors)
        {
            item.SetActive(false);
        }

        foreach (var item in closeDoors)
        {
            item.SetActive(true);
        }
    }

    public override void onLeave()
    {
        foreach (var item in openDoors)
        {
            item.SetActive(true);
        }

        foreach (var item in closeDoors)
        {
            item.SetActive(false);
        }
    }
}
