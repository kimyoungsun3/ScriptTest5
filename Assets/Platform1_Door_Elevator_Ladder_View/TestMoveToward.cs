using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveToward : MonoBehaviour {
	public Transform p0, p1;
	Vector3 v0, v1;
	Transform trans;
	public float speed = 2f;
	public float followDistance = 1f;

	private void Start()
	{
		v0 = p0.position;
		v1 = p1.position;
		trans = transform;
	}


	void Update () {
		trans.position = Vector3.MoveTowards(trans.position, v1, speed * Time.deltaTime);

		//Vector3 _dir = p1.position - trans.position;
		//if(_dir.magnitude > followDistance)
		//{
		//	trans.position = Vector3.MoveTowards(trans.position, p1.position, speed * Time.deltaTime);
		//}

	}
}
