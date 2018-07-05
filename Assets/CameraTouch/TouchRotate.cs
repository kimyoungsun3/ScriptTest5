using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate : MonoBehaviour {
	//별로임....
	float rotX, rotY;
	Camera cam;
	int touchCount;
	Touch initTouch;
	public float rotSpeed = 0.5f;
	float dir = -1;
	void Start(){
		cam = Camera.main;
		rotX = cam.transform.eulerAngles.x;
		rotY = cam.transform.eulerAngles.y;
	}

	void Update () {
		touchCount = Input.touchCount;
		if (touchCount > 0) {
			Touch _t = Input.GetTouch (0);
			if (_t.phase == TouchPhase.Began) {
				initTouch = _t;
			} else if (_t.phase == TouchPhase.Moved) {
				float _deltaX = initTouch.position.x - _t.position.x;
				float _deltaY = initTouch.position.y - _t.position.y;
				rotX -= _deltaX * Time.deltaTime * rotSpeed * rotSpeed;
				rotY += _deltaX * Time.deltaTime * rotSpeed * rotSpeed;
				rotX = Mathf.Clamp (rotX, -45f, 45f);
				cam.transform.eulerAngles = new Vector3 (rotX, rotY, 0f);
			} else if (_t.phase == TouchPhase.Ended) {
				//initTouch
			}
		}		
	}
}
