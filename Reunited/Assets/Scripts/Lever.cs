using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Usable
{
    bool state;
    bool visible = false;

    private new Renderer renderer;

    public GameObject future;

    public void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    public override void onUse()
    {
        if (visible)
        {
            state = !state;
            print("[Lever] " + state);
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
