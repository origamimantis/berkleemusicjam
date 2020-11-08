using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2[] locations;
    private int direction;
    float pause = 0;
    private Vector2 lastPoint;
    private Vector2 facing;
    int pathIdx = 0;
    bool initial = true;
    public float PauseDuration = 2;
    private float speed = 0;
    void Start()
    {
        //Sets it so the direction goes to the upper first
        direction = 0;
        locations[0] = new Vector2(transform.position.x + 5, transform.position.y);
        locations[1] = new Vector2(transform.position.x - 5, transform.position.y);
    }

    void FixedUpdate()
    {
        //If pause is greater than 0
        if (pause > 0)
        {
            pause -= Time.deltaTime;
            if (pause <= 0)
                ApplyRotate();
        }
        //Changes the position
        transform.position = Vector2.MoveTowards(transform.position, lastPoint, .4f * Time.deltaTime);

        //Checks if If the Guards at the position yet
        Vector2 delta = (Vector2)(transform.position) - locations[pathIdx];
        if (delta.magnitude > 0)
        {
            facing = delta;
        }
        else if (delta.magnitude == 0)
        {
            if (pathIdx == locations.Length - 1 || pathIdx == 0)
            {
                direction *= -1;
                if (initial == false)
                {
                    pause = PauseDuration;
                }
                else
                {
                    initial = false;
                    speed = 0;
                }
            }

            pathIdx += direction;

            if (pause == 0)
                ApplyRotate();

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void ApplyRotate()
    {
        Vector2 curDirection = locations[pathIdx];
        Vector2 rotate = facing - (curDirection - lastPoint);
        transform.right = rotate;
        transform.up = rotate;
    }
}
