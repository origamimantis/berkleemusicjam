using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PressurePlate : MonoBehaviour
{
    public abstract void onStep();
    public abstract void onLeave();

    public new string tag;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == tag)
            onStep();
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == tag)
            onLeave();
    }
}
