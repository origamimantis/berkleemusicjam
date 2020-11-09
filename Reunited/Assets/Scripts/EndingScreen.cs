using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScreen : MonoBehaviour
{
    public GameObject future;
    public GameObject player;
    public Canvas canvas;

    public Camera cam;
    public new Light light;

    float rampup = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        rampup += Time.deltaTime;

        if (rampup > 1)
            rampup = 1;

        player.transform.position = new Vector3(player.transform.position.x + rampup * Time.deltaTime * 0.3f * -player.transform.position.x, 0, -1);
        future.transform.position = new Vector3(future.transform.position.x + rampup * Time.deltaTime * 0.3f * -future.transform.position.x, 0, 0);

        float dx = Mathf.Abs(future.transform.position.x - player.transform.position.x);

        if (dx < 3)
        {
            float sin = Mathf.Sin((3 - dx) / 3.0f * Mathf.PI);
            cam.backgroundColor = new Color(255 * sin, 255 * sin, 255 * sin);

            if (dx < 0.1 && sin < 0.05f)
            {
                light.intensity -= Time.deltaTime;
            }
            else
                light.intensity = 1 + 5 * sin;
        }


        if(light.intensity <= 0)
        {
            // display text "fin"
            //canvas.enabled = true;
        }
    }
}
