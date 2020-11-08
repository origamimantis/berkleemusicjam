using System.Collections;
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

    int direction = 1;
    
    float pause = 0;
    bool initial = true;

    private Vector2 lastPoint;
    private Vector2 facing;

    // Start is called before the first frame update
    void Start()
    {
	    base.Start();
	    direction *=-1;
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
		    if (pathIdx == initialNode && initial == true)
			    initial = false;
		    else
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
