using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoundSelect{
	public class SelectsObject : MonoBehaviour {
		Vector3 startPos, endPos;
		Plane plane;
		float distance;
		int mode = 0;

		Vector3[] posArea = new Vector3[5];
		LineRenderer line;

		void Start(){
			Debug.Log (Camera.main.transform.rotation * -Vector3.forward);
			plane = new Plane (Camera.main.transform.rotation * -Vector3.forward, Vector3.zero);

			line = GetComponent<LineRenderer> ();
		}

		void Update(){
			mode = 0;
			if (Input.GetMouseButtonDown (0)) {
				Ray _ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (plane.Raycast (_ray, out distance)) {
					startPos = _ray.GetPoint (distance);
				}
				mode = 1;
			} else if (Input.GetMouseButton (0)) {
				Ray _ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (plane.Raycast (_ray, out distance)) {
					endPos = _ray.GetPoint (distance);
				}
				mode = 2;
			} else if (Input.GetMouseButtonUp (0)) {
				mode = 1;
			}

			if (mode == 2) {
				posArea [0].Set(startPos.x, startPos.y, startPos.z);
				posArea [1].Set(startPos.x, endPos.y, startPos.z);
				posArea [2].Set(endPos.x, endPos.y, startPos.z);
				posArea [3].Set(endPos.x, startPos.y, startPos.z);
				posArea [4].Set(startPos.x, startPos.y, startPos.z);
				line.SetPositions (posArea);
			}
		}
	}
}
