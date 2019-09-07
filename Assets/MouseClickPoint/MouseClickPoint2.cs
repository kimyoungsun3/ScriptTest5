using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MouseClickPoint{
	public class MouseClickPoint2 : MonoBehaviour {
		Vector3 firstPos, secondPos;
		LineRenderer line;
		Camera cam;
		Plane plane;
		float distance;
		PlayerController playerController;
		void Start () {
			playerController = PlayerController.ins;
			cam				= Camera.main;
			line			= GetComponent<LineRenderer>();		

			Vector3 _normal = cam.transform.rotation * -cam.transform.forward;
			plane = new Plane(_normal, Vector3.zero);

		}

		// Update is called once per frame
		void Update () {
			if (Input.GetMouseButtonDown (0))
			{
				//line.enabled = true;
				Ray _ray = cam.ScreenPointToRay (Input.mousePosition);
				if (plane.Raycast (_ray, out distance)) {
					firstPos = _ray.GetPoint (distance);
					firstPos.z = playerController.transform.position.z;
				}
			}

			if (Input.GetMouseButton(0))
			{
				Ray _ray = cam.ScreenPointToRay(Input.mousePosition);
				if (plane.Raycast(_ray, out distance))
				{
					secondPos = _ray.GetPoint(distance);
					secondPos.z = playerController.transform.position.z;
				}

				if ((secondPos - firstPos).magnitude < 0.3f) return;
				line.SetPosition(0, firstPos);
				line.SetPosition(1, secondPos);
			}

			if (Input.GetMouseButtonUp(0))
			{
				//line.enabled = false;
				line.SetPosition(0, Vector3.zero);
				line.SetPosition(1, Vector3.zero);
			}
		}
	}
}
