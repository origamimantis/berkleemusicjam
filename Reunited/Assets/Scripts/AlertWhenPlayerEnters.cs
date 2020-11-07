using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertWhenPlayerEnters : MonoBehaviour
{
	private FollowBase movescript;
    // Start is called before the first frame update
    void Start()
    {
	movescript = gameObject.GetComponentInParent<FollowBase>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
	if (collider.tag == "Player")
	{
	    gameObject.GetComponent<SpriteRenderer>().color = new Color (1, 0, 0, .35f); 
	    movescript.moving = false;
	}
    }
    void OnTriggerExit2D(Collider2D collider)
    {
	if (collider.tag == "Player")
	{
	    gameObject.GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, .25f); 
	    movescript.moving = true;
	}
    }
}
