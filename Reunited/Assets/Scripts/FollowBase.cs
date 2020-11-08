// ez
// base class for guard motions

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBase : MonoBehaviour
{
	[HideInInspector]
	public bool moving = true;
	public GameObject PathObject;
	public int initialNode = 0;
	protected Transform[] Path;
	protected int pathIdx = 0;

	protected void Start()
	{

		Path = new Transform[PathObject.transform.childCount];
		for (int i = 0; i < PathObject.transform.childCount; ++i)
			Path[i] = PathObject.transform.GetChild(i);

		if (initialNode >= Path.Length)
			initialNode = 0;

		transform.position = Path[initialNode].transform.position;

		Transform body = transform.GetChild(1);
		body.position = transform.position;

		Transform child = transform.GetChild(0);
		child.position = transform.position;

		pathIdx = initialNode;
	}
}
