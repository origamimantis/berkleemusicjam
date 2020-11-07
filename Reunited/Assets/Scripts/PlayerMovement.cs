using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 velocity;
    private Vector2 inputVelocity;

    public float accelSpeed = 6;
    public float maxSpeed = 10;

    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (inputVelocity.x == 0)
            velocity.x *= 0.1f;
        if (inputVelocity.y == 0)
            velocity.y *= 0.1f;
        
        inputVelocity *= Time.deltaTime * accelSpeed;

        velocity += inputVelocity;

        if (velocity.x * velocity.x + velocity.y * velocity.y > maxSpeed * maxSpeed)
        {
            velocity.Normalize();
            velocity *= maxSpeed;
        }

        body.MovePosition(new Vector2(transform.position.x + velocity.x, transform.position.y + velocity.y));
    }

    // Update is called once per frame
    void Update()
    {
        inputVelocity.y = (Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0);
        inputVelocity.x = (Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0);
    }
}
