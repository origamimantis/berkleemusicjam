using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Usable : MonoBehaviour
{
    public abstract void onUse();

    public GameObject player;

    public float interactionDistance = 2;

    protected bool canBeUsedBy(GameObject go)
    {
        float dx = go.transform.position.x - transform.position.x;
        float dy = go.transform.position.y - transform.position.y;
        double dist = dx * dx + dy * dy;

        return dist <= interactionDistance * interactionDistance;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canBeUsedBy(player))
        {
            onUse();
        }
    }
}
