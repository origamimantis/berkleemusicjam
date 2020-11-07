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
	protected Transform[] Path;

	protected void Start()
	{
		Path = new Transform[PathObject.transform.childCount];
		for (int i = 0; i < PathObject.transform.childCount; ++i)
			Path[i] = PathObject.transform.GetChild(i);

		transform.position = Path[0].transform.position;

		Transform body = transform.GetChild(1);
		body.position = Path[0].transform.position;

		Transform child = transform.GetChild(0);
		child.position = transform.position;
	}
}
