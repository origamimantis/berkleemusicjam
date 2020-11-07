using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    private float speed = 0;
    private Vector2 inputVelocity;

    public float accelSpeed = 1;
    public float maxSpeed = 1;
    // will pause at end of path for at least PauseDuration
    public float PauseDuration = 2;
    // At end of path, head back the other way.
    // if false, will loop back to the beginning.
    public bool reverse = true;

    public Transform[] Path;

    int direction = 1;
    
    float pause = 0;

    Rigidbody2D body;
    int pathIdx = 0;
    private Vector2 lastDirection = new Vector2(0f,0f);

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
	transform.position = Path[0].transform.position;
	if (reverse == true)
		direction = -1;
    }

    void FixedUpdate()
    {
	if (pause > 0)
	{
		pause -= Time.deltaTime;
	}
	else
	{
	    speed = Mathf.Min(maxSpeed, speed + Time.deltaTime * accelSpeed);

	    transform.position = Vector2.MoveTowards(transform.position,
		    Path[pathIdx].transform.position,
		    speed * Time.deltaTime);
	    Vector2 delta = transform.position - Path[pathIdx].transform.position;
	    if (delta.magnitude == 0)
	    {
	        if (reverse == true)
	        {
    	            if (pathIdx == Path.Length - 1 || pathIdx == 0)
	            {
		        direction *= -1;
		        pause = PauseDuration;
		        speed = 0;
		    }
		}
		else
		{
    	            if (pathIdx == Path.Length - 1)
	            {
			pathIdx = -1;
		    }
		}
	        pathIdx += direction;
	    }
	}
    
    }
}
