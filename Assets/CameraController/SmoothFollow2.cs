using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow2 : MonoBehaviour {
	Transform trans;

	public Transform target;
	public float distance = 10f;
	public float height = 5f;
	public float heightDamping = 2.0f;
	public float rotationDamping = 3.0f;
	float wantedRotationAngle, wantedHeight;
	float currentRotationAngle, currentHeight;
	Quaternion currentRotation;
	Vector3 pos;

	void Start () {
		trans = transform;	

	}

	void LateUpdate () {
		if (target == null) {
			return;
		}

		wantedRotationAngle 	= target.eulerAngles.y;
		wantedHeight 			= target.position.y + height;

		currentRotationAngle 	= trans.eulerAngles.y;
		currentHeight 			= trans.position.y;

		//currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
		//currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
		//currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
		//currentRotationAngle = wantedRotationAngle;
		currentRotation = Quaternion.Euler (0, wantedRotationAngle, 0);
		currentHeight = wantedHeight;

		//Set the position of the camera on the x-z plane to;
		//distance meters behind the target
		trans.position = target.position;
		trans.position -= currentRotation * Vector3.forward * distance;

		pos.Set (trans.position.x, currentHeight, trans.position.z);
		trans.position = pos;
		trans.LookAt (target);
	}
}
