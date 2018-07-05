using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWorld : MonoBehaviour {
	public Transform target;

	 
	void Update () {
		Vector3 _sp = Camera.main.WorldToScreenPoint (target.position);
		Vector3 _vp = Camera.main.WorldToViewportPoint (target.position);

		Debug.Log ("wp:" + target.position
			+ " sp:" + _sp
			+ " vp:" + _vp
		); 
		
	}
}
