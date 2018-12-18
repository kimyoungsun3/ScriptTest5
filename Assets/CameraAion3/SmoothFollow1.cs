using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow1 : MonoBehaviour {
	Transform trans;

	public Transform target;
	public float distance = 10f;
	public float height = 5f;
	Quaternion currentRotation;

	void Start () {
		trans = transform;	

	}

	void LateUpdate () {
		if (target == null) {
			return;
		}
		currentRotation = Quaternion.Euler (0, target.eulerAngles.y, 0);
		trans.position = target.position
			+ currentRotation * (-Constant.V3_FORWARD) * distance
			+ Constant.V3_UP * height;
		trans.LookAt (target);
	}
}
