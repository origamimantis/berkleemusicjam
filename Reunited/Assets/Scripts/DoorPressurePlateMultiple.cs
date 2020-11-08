using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPressurePlateMultiple: PressurePlate
{
    public GameObject[] others;
    public GameObject[] openDoors;
    public GameObject[] closeDoors;

    private DoorPressurePlateMultiple[] plateScripts;

    protected int currentlyOn = 0;

    public bool Active()
    {
        return currentlyOn > 0;
    }

    public void Start()
    {
        plateScripts = new DoorPressurePlateMultiple[others.Length];
        for (int i = 0; i < others.Length; i++)
            plateScripts[i] = others[i].GetComponent<DoorPressurePlateMultiple>();
    }

    public override void onStep()
    {
        currentlyOn++;

        foreach (DoorPressurePlateMultiple plate in plateScripts)
            if (!plate.Active())
                return;

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
