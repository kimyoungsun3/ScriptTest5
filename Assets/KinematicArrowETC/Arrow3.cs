using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KinematicArrowETC{
	public class Arrow3 : MonoBehaviour {
		public Transform sunrise;
		public Transform sunset;
		public float journeyTime = 1f;
		float startTime;
		Vector3 beforePos;

		void Start(){
			startTime = Time.time;
			beforePos = transform.position;
		}
	 	  
	    void Update() {
			Vector3 _center = (sunrise.position + sunset.position) * 0.5f;
			_center -= Vector3.up;

			Vector3 _riseRelCenter = sunrise.position - _center;
			Vector3 _setRelCenter = sunset.position - _center;

			float _fracComplete = (Time.time - startTime) / journeyTime;
			transform.position = Vector3.Slerp (_riseRelCenter, _setRelCenter, _fracComplete);
			transform.position += _center;

			transform.rotation = Util.GetQuaternionFromDir2D(transform.position - beforePos);
			beforePos = transform.position;
		}


	}
}