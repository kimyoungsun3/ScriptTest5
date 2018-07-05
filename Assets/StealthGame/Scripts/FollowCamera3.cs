using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera3 : MonoBehaviour {
	public Transform target;
	public float distance = 10f;
	public float height = 5f;
	public float heightDamping = 2f;
	public float rotationDampoing =3f;

	//void Start () {
	//	offset = transform.position - target.position;
	//}

	float wantAngle, wantHeight;
	float currentAngle, currentHeight;
	Quaternion currentRotation;
	void LateUpdate () {
		if (target == null)
			return;

		wantAngle = target.eulerAngles.y;
		wantHeight = target.position.y + height;

		currentAngle = transform.eulerAngles.y;
		currentHeight = transform.position.y;

		//prop = Mathf.LerpAngle(currentAngle, wantAngle, 0 ~ 1);
		currentAngle = Mathf.LerpAngle (currentAngle, wantAngle, rotationDampoing * Time.deltaTime);
		currentHeight = Mathf.Lerp (currentHeight, wantHeight, heightDamping * Time.deltaTime);
		currentRotation = Quaternion.Euler (Vector3.up * currentAngle);

		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;

		transform.position = new Vector3 (transform.position.x, currentHeight, transform.position.z);

		transform.LookAt (target);
	}
}
