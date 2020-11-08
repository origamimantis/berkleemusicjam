using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject player;
    public GameObject future;
    private Transform[] ends;
    private bool[] cantele;
    // Start is called before the first frame update
    void Start()
    {
	    ends = new Transform[2];
	    ends[0] =  transform.GetChild(0);
	    ends[1] =  transform.GetChild(1);
	    cantele = new bool[2];
	    cantele[0] = true;
	    cantele[1] = true;
    }

    // Update is called once per frame
    void Update()
    {
	    float[] mins = new float[2]{100,100};
	    for (int i = 0; i < 2; ++i)
	    {
		Vector2 delta = player.transform.position - ends[i].position;
		if (delta.magnitude < mins[0])
			mins[0] = delta.magnitude;
	    	if (cantele[0] == true && delta.magnitude < 0.5)
		{
			player.transform.position = (Vector2)ends[1-i].position + delta;
			cantele[0] = false;

			//Finds portal sound effect from audio sources and plays once.
			AudioSource portal = GameObject.FindGameObjectWithTag("Portal").GetComponent(typeof(AudioSource)) as AudioSource;
			portal.Play();
			}

		delta = future.transform.position - ends[i].position;
		if (delta.magnitude < mins[1])
			mins[1] = delta.magnitude;
	    	if (cantele[1] == true && delta.magnitude < 0.5)
		{
			future.transform.position = (Vector2)ends[1-i].position + delta;
			cantele[1] = false;

			//Finds portal sound effect from audio sources and plays once.
			AudioSource portal = GameObject.FindGameObjectWithTag("Portal").GetComponent(typeof(AudioSource)) as AudioSource;
			portal.Play();
			}
	    }
		if (cantele[0] == false && mins[0] > 1)
			cantele[0] = true;

		if (cantele[1] == false && mins[1] > 1)
			cantele[1] = true;

        
    }
}
