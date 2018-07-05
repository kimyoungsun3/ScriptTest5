using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public bool bSmooth;
	public Transform target;
	Vector3 offset, pos2;
	Transform trans;

	void Start () {
		trans = transform;
		offset = target.position - trans.position;	
	}
	
	void Update () {
		if (bSmooth) {
			trans.position = Vector3.Lerp (trans.position, target.position - offset, 0.1f);
		} else {
			trans.position = target.position - offset;
		}

	}
}
