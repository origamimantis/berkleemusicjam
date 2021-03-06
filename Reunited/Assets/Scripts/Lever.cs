﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Usable
{
    public bool state = false;
    public bool visible = false;

    private new Renderer renderer;

    public GameObject future;

    public Sprite off;
    public Sprite on;

    public GameObject changeState;

    public void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.SetTexture("_SecondaryTex", state ? on.texture : off.texture);

        changeState.SetActive(!state);
    }

    public override void onUse()
    {
        if (visible)
        {
            state = !state;
            renderer.material.SetTexture("_SecondaryTex", state ? on.texture : off.texture);

            changeState.SetActive(!state);

            //Finds lever sound effect from audio sources and plays once.
            AudioSource lever = GameObject.FindGameObjectWithTag("Lever").GetComponent(typeof(AudioSource)) as AudioSource;
            lever.Play();
        }
    }

    public override void Update()
    {
        base.Update();

        if(!visible)
        {
            renderer.sharedMaterial.SetVector("_futureLocation", new Vector4(future.transform.position.x, future.transform.position.y, future.transform.position.z, 0));
        }
        else
        {
            renderer.sharedMaterial.SetVector("_futureLocation", new Vector4(transform.position.x, transform.position.y, transform.position.z, 0));
        }

        if (canBeUsedBy(future, 2.5f))
        {
            visible = true;

            renderer.sharedMaterial.SetVector("_futureLocation", new Vector4(transform.position.x, transform.position.y, transform.position.z, 0));
        }
    }
}
