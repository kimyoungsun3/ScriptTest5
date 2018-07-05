using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
	public Transform target;
	public Vector3 offset;
	public float speedMove = 10f;
	public float speedTurn = 180f;
	Vector3 angle;

	void Start () {
		//offset = transform.position - target.position;
		angle = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		transform.position = Vector3.Lerp(transform.position, target.position + offset, speedMove * Time.deltaTime);
		transform.rotation = Quaternion.Lerp (transform.rotation, target.rotation, speedTurn * Time.deltaTime);
		transform.rotation *= Quaternion.Euler (Vector3.right * angle.x);
	}
}
