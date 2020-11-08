using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject future;
    public GameObject player;
    public float lerp = 0.1f;
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 intermediate = new Vector2(future.transform.position.x + player.transform.position.x, future.transform.position.y + player.transform.position.y);
        intermediate /= 2;

        // 12 = 5/12x
        float dx = future.transform.position.x - player.transform.position.x;
        float dy = future.transform.position.y - player.transform.position.y;

        cam.orthographicSize += lerp * (Mathf.Max(5, 5 / 10.0f * Mathf.Sqrt(dx * dx + dy * dy)) - cam.orthographicSize);

        Vector2 delta = intermediate - new Vector2(transform.position.x, transform.position.y);

        delta *= lerp;
        transform.position = new Vector3(transform.position.x + delta.x, transform.position.y + delta.y, -20);
    }
}
