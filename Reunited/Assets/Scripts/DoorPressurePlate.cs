using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPressurePlate : PressurePlate
{
    public GameObject[] openDoors;
    public GameObject[] closeDoors;

    protected int currentlyOn = 0;

    public bool Active()
    {
        return currentlyOn > 0;
    }
    
    public override void onStep()
    {
        currentlyOn++;

        foreach (var item in openDoors)
        {
            item.SetActive(false);
        }

        foreach (var item in closeDoors)
        {
            item.SetActive(true);
        }

        //Finds lever sound effect from audio sources and plays once.
        AudioSource pressurePlate = GameObject.FindGameObjectWithTag("PressurePlate").GetComponent(typeof(AudioSource)) as AudioSource;
        pressurePlate.Play();
    }

    public override void onLeave()
    {
        currentlyOn--;
        if (currentlyOn < 0)
            currentlyOn = 0;

        if (currentlyOn == 0)
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
}
