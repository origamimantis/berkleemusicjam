using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 velocity;
    private Vector2 inputVelocity;

    public float accelSpeed = 6;
    public float maxSpeed = 10;

    private AudioSource walk1;
    private AudioSource walk2;
    private AudioSource walk3;
    private AudioSource walk4;
    private AudioSource walk5;
    private AudioSource walk6;
    private AudioSource walk7;
    private int walkDelay = 0;
    private const int SOUND_DELAY = 20;

    private System.Random rand;

    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        //Finds footsteps
        walk1 = GameObject.FindGameObjectWithTag("Walk1").GetComponent(typeof(AudioSource)) as AudioSource;
        walk2 = GameObject.FindGameObjectWithTag("Walk2").GetComponent(typeof(AudioSource)) as AudioSource;
        walk3 = GameObject.FindGameObjectWithTag("Walk3").GetComponent(typeof(AudioSource)) as AudioSource;
        walk4 = GameObject.FindGameObjectWithTag("Walk4").GetComponent(typeof(AudioSource)) as AudioSource;
        walk5 = GameObject.FindGameObjectWithTag("Walk5").GetComponent(typeof(AudioSource)) as AudioSource;
        walk6 = GameObject.FindGameObjectWithTag("Walk6").GetComponent(typeof(AudioSource)) as AudioSource;
        walk7 = GameObject.FindGameObjectWithTag("Walk7").GetComponent(typeof(AudioSource)) as AudioSource;

        rand = new System.Random();
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

        //Checks if player is moving, if so, plays sound, else sets it so that the next sound is instant.
        if (Math.Abs(velocity.x) > .1f || Math.Abs(velocity.y) > .1f)
            GenerateFootsteps();
        else
            walkDelay = 100;
    }

    // Update is called once per frame
    void Update()
    {
        inputVelocity.y = (Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0);
        inputVelocity.x = (Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0);

        if(tag.Equals("Finish"))
        {
            Shader.SetGlobalVector("_futureLocation", 
                new Vector4(transform.position.x, transform.position.y, transform.position.z, 0));
        }
    }

    /// <summary>
    /// Generates sounds for walking, only occurs when player is moving. Loops through different walk sounds.
    /// Uses Random() to choose walk sound. Uses a const SOUND_DELAY updated in the FixedUpdate to make consistent.
    /// </summary>
    private void GenerateFootsteps()
    {
        if (walkDelay > SOUND_DELAY)
        {
            int randomNum = rand.Next(1, 8);

            switch (randomNum)
            {
                case 1:
                    walk1.Play();
                    break;
                case 2:
                    walk2.Play();
                    break;
                case 3:
                    walk3.Play();
                    break;
                case 4:
                    walk4.Play();
                    break;
                case 5:
                    walk5.Play();
                    break;
                case 6:
                    walk6.Play();
                    break;
                case 7:
                    walk7.Play();
                    break;
            }
            walkDelay = 0;
        }
        walkDelay++;
    }
}
