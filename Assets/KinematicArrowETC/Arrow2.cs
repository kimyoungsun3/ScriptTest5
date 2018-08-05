using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KinematicArrowETC{
	public class Arrow2 : MonoBehaviour {
		public Transform target;
		public Transform curvePoint;
		public float speed = 1f;
		float t = 0f;
		Vector3 pos, beforePos;

		void Start(){
			pos = transform.position;
			beforePos = transform.position;
		}
	 	  
	    void Update() {
			transform.position = Bezier (pos, curvePoint.position, target.position, t);
			transform.rotation = Util.GetQuaternionFromDir2D(transform.position - beforePos);
			beforePos = transform.position;
			t = Mathf.Min (1, t + Time.deltaTime * speed);

			Vector3 _a, _b;
			for (int i = 0; i < 19; i++) {
				_a = Bezier (pos, curvePoint.position, target.position, i       * 1f / 20f);
				_b = Bezier (pos, curvePoint.position, target.position, (i + 1) * 1f / 20f);
				Debug.DrawLine (_a, _b);
			}
	    }

		Vector3 Bezier(Vector3 _a, Vector3 _b, Vector3 _c, float _t){
			float _omt = 1f - t;
			return _a * _omt * _omt + 2f * _b * _omt * _t + _c * _t * _t;
		}
	}
}