using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLerp : MonoBehaviour {
	public Transform p0, p1;
	[Range(0, 1f)]public float interval = 0.5f;
	Transform trans;

	void Start () {
		trans = transform;
	}
	
	// Update is called once per frame
	void Update () {
		// p0 ------ p1
		//trans.position = Vector3.Lerp(p0.position, p1.position, interval);
		//trans.rotation = Quaternion.Lerp(p0.rotation, p1.rotation, interval);


		// t ------- p1
		trans.position = Vector3.Lerp(trans.position, p1.position, interval);
		trans.rotation = Quaternion.Lerp(trans.rotation, p1.rotation, interval);
	}
}
