using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMove2 : MonoBehaviour {
	int touchCount;
	float speed = 30;
	void Update () {
		touchCount = Input.touchCount;
		if(touchCount > 0){
			Touch[] _touches = Input.touches;
			Touch _t = _touches [0];
			Debug.Log ("phase:" + _t.phase);
			/*
			Debug.Log ("fingerId:" + _t.fingerId
				+ " position:" + _t.position
				+ " deltaPosition:" + _t.deltaPosition
			);
			Debug.Log ("phase:" + _t.phase
				+ " tapCount:" + _t.tapCount
			);
			Debug.Log ("Time.deltaTime:" + Time.deltaTime
				+ " deltaTime:" + _t.deltaTime
			);
			*/


			if (touchCount == 1){
				if (_t.phase == TouchPhase.Began) {
					Debug.Log (" Touch Began");
				} else if (_t.phase == TouchPhase.Ended) {
					Debug.Log (" Touch Ended");
				} else if (_t.phase == TouchPhase.Moved) {
					Debug.Log (" Touch Moved");
				}



				transform.Rotate (Vector3.up * speed * Time.deltaTime);
			} else if (touchCount == 2) {
				Debug.Log ("resize");
			}
		}
		
	}
}
