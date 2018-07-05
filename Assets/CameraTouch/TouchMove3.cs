using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMove3 : MonoBehaviour {
	GameObject gObj;
	Plane objPlane;
	Vector3 m0;
	int touchCount;

	Ray GenerateMouseRay(Vector3 _touchPos){
		Vector3 _mousePosFar = new Vector3 (_touchPos.x, _touchPos.y, Camera.main.farClipPlane);
		Vector3 _mousePosNear = new Vector3 (_touchPos.x, _touchPos.y, Camera.main.nearClipPlane);
		Vector3 _mousePosF = Camera.main.ScreenToWorldPoint (_mousePosFar);
		Vector3 _mousePosN = Camera.main.ScreenToWorldPoint (_mousePosNear);
		return new Ray (_mousePosN, _mousePosF - _mousePosN);
	}


	void Update () {
		touchCount = Input.touchCount;
		if(touchCount > 0){
			Touch _t = Input.GetTouch(0);
			if (_t.phase == TouchPhase.Began) {
				Ray _mouseRay = GenerateMouseRay (_t.position);
				RaycastHit _hit;
				if (Physics.Raycast (_mouseRay, out _hit)) {
					gObj = _hit.transform.gameObject;
					objPlane = new Plane (-Camera.main.transform.forward, gObj.transform.position);

					Ray _mRay = Camera.main.ScreenPointToRay (_t.position);
					float _distance;
					objPlane.Raycast (_mRay, out _distance);
					m0 = gObj.transform.position - _mRay.GetPoint (_distance);
				}

			} else if (_t.phase == TouchPhase.Moved && gObj) {
				//Debug.Log (" Touch Moved");
				Ray _mRay = Camera.main.ScreenPointToRay(_t.position);
				float _distance;
				if (objPlane.Raycast (_mRay, out _distance)) {
					gObj.transform.position = _mRay.GetPoint (_distance) + m0;
				}
			} else if (_t.phase == TouchPhase.Ended) {				
				//Debug.Log (" Touch Ended");
				gObj = null;
			}
		}		
	}
}
