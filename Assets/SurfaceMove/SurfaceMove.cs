using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceMove : MonoBehaviour {
	public LayerMask mask;
	Ray ray;
	RaycastHit hit;
	void Update () {
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, 100, mask)) {
			transform.position = hit.point;
			transform.rotation = Quaternion.FromToRotation (Vector3.up, hit.normal);
			//transform.rotation = Quaternion.FromToRotation (Vector3.forward, hit.normal);
			//transform.rotation = Quaternion.LookRotation(hit.normal);
			//transform.rotation = Quaternion.FromToRotation (Vector3.forward, -hit.normal);
			//
		}
	}
}
