using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewPort : MonoBehaviour {
	public Vector3 viewport;
	Vector3 wp;
	void Update () {
		Ray _ray = Camera.main.ViewportPointToRay (viewport);
		wp = Camera.main.ViewportToWorldPoint (viewport);
		Vector3 _sp = Camera.main.ViewportToScreenPoint(viewport);

		Debug.DrawRay (_ray.origin, _ray.direction, Color.white);

		Debug.Log ("ViewportPointToRay:" + viewport + ":" + _ray.origin + ", " + _ray.direction);
		Debug.Log ("ViewportToWorldPoint:" + wp);
		Debug.Log ("ViewportToScreenPoint:" + _sp);
	
	}

	void OnDrawGizmos(){
		//Debug.Log (1);
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere (wp, .5f);
	}
}
