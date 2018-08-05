using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KinematicArrowETC{
	public class Arrow : MonoBehaviour {
		public float power = 10f;
		public float rotateSpeed = 10;
		public Transform target;
	 	  
	    void Update() {
			Vector3 _dir = target.position - transform.position;
			transform.rotation = Quaternion.RotateTowards( transform.rotation, Util.GetQuaternionFromDir2D(_dir), rotateSpeed);	
			transform.Translate (Vector3.right * power * Time.deltaTime);
			if (_dir.magnitude < 1) {
				gameObject.SetActive (false);
			}
	    }
	}
}