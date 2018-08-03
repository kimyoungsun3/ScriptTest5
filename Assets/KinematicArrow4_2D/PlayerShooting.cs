using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolManager7;

namespace KinematicArrow4{
	public class PlayerShooting : MonoBehaviour {
		Plane plane;
		Ray ray;
		Camera cam;
		Transform trans;
		float distance;
		Vector3 hitPoint;
		public Transform target;
		float nextTime;
		public float NEXT_TIME = 0.1f;

		// Use this for initialization
		void Start () {
			cam = Camera.main;
			trans = transform;
			plane = new Plane (Vector3.back, Vector3.zero);		
		}
		
		// Update is called once per frame
		void Update () {
			if (Time.time > nextTime && Input.GetMouseButton (0)) {
				nextTime = Time.time + NEXT_TIME;
				ray = cam.ScreenPointToRay (Input.mousePosition);
				if (plane.Raycast (ray, out distance)) {
					hitPoint = ray.GetPoint (distance);
					ArrowMove _scp = PoolManager.ins.Instantiate ("Arrow", hitPoint, Quaternion.identity).GetComponent<ArrowMove> ();
					if (_scp != null) {
						_scp.CoShooting (hitPoint, target);
					}
				}
			} else if (Input.GetMouseButtonDown (1)) {
				if (Time.timeScale == 1f) {
					Time.timeScale = 2f;
				} else if (Time.timeScale == 2f) {
					Time.timeScale = 5f;
				} else if (Time.timeScale == 5f) {
					Time.timeScale = 1f;
				}

			}
		}
	}
}