using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPosition : MonoBehaviour {


	void OnMouseDown(){
		Debug.Log (this + " : " + transform.position + ":" + transform.localPosition);
	}

	float radius;
	Vector3 dir;
	float speed = 2f;
	void Start(){
		radius = transform.localPosition.magnitude;
	}

	void Update(){
		dir.Set (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"), 0);
		dir = dir.normalized;
		if (dir != Vector3.zero) {
			transform.position += dir * speed * Time.deltaTime;
			transform.localPosition = Vector3.ClampMagnitude (transform.localPosition, radius);
		}
	}
}
