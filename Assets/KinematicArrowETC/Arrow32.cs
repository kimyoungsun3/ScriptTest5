using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KinematicArrowETC{
	public class Arrow32 : MonoBehaviour {
		public Transform target;
		public float journeyTime = 1f;
		float startTime;
		Vector3 posStart, posEnd, posBefore;

		void Start(){
			startTime = Time.time;

			posStart 	= transform.position;
			posEnd 		= target.position;
			posBefore 	= transform.position;
		}
	 	  
	    void Update() {
			Vector3 _center = (posStart + posEnd) * 0.5f;
			_center -= Vector3.up;

			Vector3 _dirStart 	= posStart - _center;
			Vector3 _dirEnd 	= posEnd - _center;

			float _fracComplete = (Time.time - startTime) / journeyTime;
			transform.position = Vector3.Slerp (_dirStart, _dirEnd, _fracComplete);
			transform.position += _center;

			transform.rotation = Util.GetQuaternionFromDir2D(transform.position - posBefore);
			posBefore = transform.position;
		}


	}
}