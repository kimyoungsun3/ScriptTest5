using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreen : MonoBehaviour {
	Vector3 wp;
	void Update () {
		Ray _ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		wp = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 _vp = Camera.main.ScreenToViewportPoint (Input.mousePosition);

		Debug.DrawRay (_ray.origin, _ray.direction, Color.white);

		Debug.Log ("ScreenPointToRay:" + Input.mousePosition + ":" + _ray.origin + ", " + _ray.direction);
		Debug.Log ("ScreenToWorldPoint:" + wp);
		Debug.Log ("ScreenToViewportPoint:" + _vp);
	
	}

	void OnDrawGizmos(){
		//Debug.Log (1);
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere (wp, .5f);
	}
}
