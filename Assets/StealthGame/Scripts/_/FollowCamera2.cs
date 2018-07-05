using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera2 : MonoBehaviour {
	public Transform target;
	public Vector3 offset;

	void Start () {
		offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = target.TransformPoint (offset);
		transform.LookAt (target);
	}
}
