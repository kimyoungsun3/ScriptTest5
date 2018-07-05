using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraShake2D{
	public class CameraShake2D3 : MonoBehaviour {
		Camera cam;
		Transform trans;

		//public AnimationCurve curve;
		float shakeStartTime, shakeEndTime;
		public float shakeDurationTime = .5f;
		public float shakeOffX = 1f;
		Vector3 oldPos, offSet;
		bool bShakeStart, bShakeEnd;

		// Use this for initialization
		void Awake () {
			cam 	= GetComponent<Camera>();	
			trans 	= cam.transform;
			oldPos 	= trans.position;

			Debug.Log ("Num 2 is Screen Shake(LateUpdate)");
		}

		// Update is called once per frame
		void LateUpdate () {
			//Debug.Log (this + ":" + 2);
			if (Input.GetKeyDown (KeyCode.Alpha3)) {
				shakeStartTime 	= Time.time;
				shakeEndTime 	= Time.time + shakeDurationTime;
				//oldPos 		= trans.position;
				Debug.Log (" > Shaking LateUpdate");
			}

			if (Time.time < shakeEndTime) {
				float _interval = (Time.time - shakeStartTime) / shakeDurationTime;
				offSet = Random.insideUnitCircle * shakeOffX;
				trans.position = oldPos + offSet;

				bShakeStart = true;
				bShakeEnd	= false;
			} else {
				bShakeEnd = true;
			}

			//Original Position
			if (bShakeStart && bShakeEnd) {
				trans.position = oldPos;
				bShakeStart = false;
				bShakeEnd	= false;
			}
		}
	}
}