using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    private new Light light;
    private float offset;
    private float offset2;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponentInChildren<Light>();

        offset = Random.value * 50;
        offset2 = Random.value * 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        light.intensity = 1.5f + 0.5f * Mathf.Sin((offset + Time.fixedTime));
    }
}
