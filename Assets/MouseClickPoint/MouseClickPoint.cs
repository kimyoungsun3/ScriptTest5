using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MouseClickPoint{
	public class MouseClickPoint : MonoBehaviour {

		Camera cam;
		Transform trans;
		Plane plane;
		PlayerController playerController;
		float distance;
		Vector3 hitPoint;

		// Use this for initialization
		void Start () {
			trans = transform;

			cam = GetComponent<Camera> ();
			playerController = PlayerController.ins;
			Vector3 _normal = trans.rotation * -trans.forward;
			plane = new Plane (_normal, Vector3.zero);
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetMouseButton (0)) {
				//Debug.Log (11);
				Ray _ray = cam.ScreenPointToRay (Input.mousePosition);
				if (plane.Raycast (_ray, out distance)) {
					//Debug.Log (12);
					hitPoint = _ray.GetPoint (distance);
					hitPoint.z = playerController.transform.position.z;
					Debug.DrawRay (playerController.transform.position, hitPoint, Color.green);
				}
			}
		}
	}
}
