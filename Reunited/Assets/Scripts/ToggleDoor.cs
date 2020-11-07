// Eric Zhang
// 11/6/2020
// this script makes collisions with an object with this behavior
// (a button) disable collisions for <target>.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleDoor : MonoBehaviour
{
    // objects to disble collisions for (doors)
    public GameObject[] targets;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
	foreach (GameObject target in targets)
	{
	    target.GetComponent<BoxCollider2D>().isTrigger = true;
	    target.GetComponent<Renderer>().enabled = false;
	}
    }
    private void OnTriggerExit2D(Collider2D col)
    {
	foreach (GameObject target in targets)
	{
	    target.GetComponent<BoxCollider2D>().isTrigger = false;
	    target.GetComponent<Renderer>().enabled = true;
	}
    }
}
