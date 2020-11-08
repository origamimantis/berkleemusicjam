using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlertWhenPlayerEnters : MonoBehaviour
{
	public GameObject player;
	public GameObject future;

	private FollowBase movescript;
	private float timeSeen = 0;
	private bool seen = false;
	private bool lose = false;

	public LossMenu loss;

    // Start is called before the first frame update
    void Start()
    {
		movescript = gameObject.GetComponentInParent<FollowBase>();
		loss = FindObjectOfType<LossMenu>();
    }

    // Update is called once per frame
    void Update()
    {
	    if (seen)
	    {
		    timeSeen += Time.deltaTime;
	    }
	    if (timeSeen > 0.2f && lose == false)
	    {
		    lose = true;
		    Invoke("OnLose", 0f);
	    }
    }
    void OnLose()
    {
		loss.LossScreen();

		//Finds die sound effect from audio sources and plays once.
		AudioSource die = GameObject.FindGameObjectWithTag("Loss").GetComponent(typeof(AudioSource)) as AudioSource;
		die.Play();
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
	// raycast to avoid sight through walls
	//
	
	if (collider.gameObject == player || collider.gameObject == future)
	{
	    Vector2 eyePos = transform.position - transform.up.normalized*0.5f;
	    Vector2 delta = (Vector2)collider.transform.position - eyePos; 
	    RaycastHit2D hit = Physics2D.Raycast(eyePos, delta, delta.magnitude);
	    
	    
	    if (hit.collider.gameObject == player || hit.collider.gameObject == future)
	    {
	        gameObject.GetComponent<SpriteRenderer>().color = new Color (1, 0, 0, .35f); 
	        movescript.moving = false;
	        seen = true;
	        timeSeen = 0;
	    }
	}
    }
    void OnTriggerExit2D(Collider2D collider)
    {
	if (collider.gameObject == player || collider.gameObject == future)
	{
	    gameObject.GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, .25f); 
	    movescript.moving = true;
	    seen = false;
	}
    }
}
