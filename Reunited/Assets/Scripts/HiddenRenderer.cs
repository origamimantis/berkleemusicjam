using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenRenderer : MonoBehaviour
{
    public GameObject future;
    private new Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        renderer.sharedMaterial.SetVector("_futureLocation", new Vector4(future.transform.position.x, future.transform.position.y, future.transform.position.z, 0));
    }
}
