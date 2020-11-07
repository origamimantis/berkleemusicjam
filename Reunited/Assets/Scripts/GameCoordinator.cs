using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoordinator : MonoBehaviour
{
    private LineRenderer lineRenderer;

    public GameObject player;
    public GameObject future;

    private Vector3[] linePositions;

    // Start is called before the first frame update
    void Start()
    {
        linePositions = new Vector3[2];

        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        linePositions[0] = player.transform.position;
        linePositions[1] = future.transform.position;

        lineRenderer.SetPositions(linePositions);

        lineRenderer.startWidth = .5f;
        lineRenderer.endWidth = 1f;
    }
}
