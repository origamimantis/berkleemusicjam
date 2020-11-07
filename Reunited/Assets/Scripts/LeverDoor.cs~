using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoor : Usable
{
    public bool state = false;
    bool visible = false;

    private new Renderer renderer;

    public GameObject future;

    public Sprite off;
    public Sprite on;

    public GameObject[] Doors;

    public void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.SetTexture("_SecondaryTex", state ? on.texture : off.texture);
    }

    public override void onUse()
    {
        if (visible)
        {
            state = !state;
            renderer.material.SetTexture("_SecondaryTex", state ? on.texture : off.texture);
	    foreach (GameObject Door in Doors)
	    {
		    Door.GetComponent<BoxCollider2D>().isTrigger = true;
		    Door.GetComponent<Renderer>().enabled = false;
	    }

        }
    }

    public override void Update()
    {
        base.Update();

        if(!visible)
        {
            renderer.sharedMaterial.SetVector("_futureLocation", new Vector4(future.transform.position.x, future.transform.position.y, future.transform.position.z, 0));
        }

        if (canBeUsedBy(future))
        {
            visible = true;

            renderer.sharedMaterial.SetVector("_futureLocation", new Vector4(transform.position.x, transform.position.y, transform.position.z, 0));
        }
    }
}
