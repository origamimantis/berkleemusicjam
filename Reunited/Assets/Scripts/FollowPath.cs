﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : FollowBase
{
    private float speed = 0;
    private Vector2 inputVelocity;

    public float accelSpeed = 1;
    public float maxSpeed = 1;
    // will pause at end of path for at least PauseDuration
    public float PauseDuration = 2;

    public Transform[] Path;

    int direction = -1;
    
    float pause = 0;

    int pathIdx = 0;
    private Vector2 lastPoint;
    private Vector2 facing;

    // Start is called before the first frame update
    void Start()
    {
	transform.position = Path[0].transform.position;

        Transform body = transform.GetChild(1);
	body.position = Path[0].transform.position;

        Transform child = transform.GetChild(0);
	child.position = transform.position;
    }

    void FixedUpdate()
    {
	if (moving == false)
		return;
	if (pause > 0)
	{
		pause -= Time.deltaTime;
		if (pause <= 0)
		    ApplyRotate();
	}
	else
	{
	    pause = 0;
	    speed = Mathf.Min(maxSpeed, speed + Time.deltaTime * accelSpeed);
	    lastPoint = Path[pathIdx].transform.position;

	    transform.position = Vector2.MoveTowards(transform.position,
		    lastPoint, speed * Time.deltaTime);
	    Vector2 delta = transform.position - Path[pathIdx].transform.position;
	    if (delta.magnitude > 0)
	    {
		    facing = delta;
	    }
	    else if (delta.magnitude == 0)
	    {
    	        if (pathIdx == Path.Length - 1 || pathIdx == 0)
	        {
		    direction *= -1;
		    pause = PauseDuration;
		    speed = 0;
		}

	        pathIdx += direction;

		if (pause == 0)
		    ApplyRotate();
		
	    }
	}
    
    }
    void ApplyRotate()
    {
	Vector2 curDirection = Path[pathIdx].transform.position;
	Vector2 rotate = facing - (curDirection - lastPoint);
	transform.right = rotate;
	transform.up = rotate;
    }
}