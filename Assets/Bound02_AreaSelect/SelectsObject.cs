using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bound02{
	public class SelectsObject : MonoBehaviour {
		Vector3 startPos, endPos;
		Plane plane;
		float distance;
		int mode = 0;
		Bounds hitBounds;
		Vector3 hitMin, hitMax;

		Vector3[] posArea = new Vector3[5];
		LineRenderer lineRenderer;
		CreateObject scpObject;

		void Start(){
			//Debug.Log (Camera.main.transform.rotation * -Vector3.forward);
			plane = new Plane (Camera.main.transform.rotation * -Vector3.forward, Vector3.zero);

			lineRenderer = GetComponent<LineRenderer> ();
			scpObject = GetComponent<CreateObject> ();
		}

		void Update(){
			mode = 0;
			if (Input.GetMouseButtonDown (0)) {
				Ray _ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (plane.Raycast (_ray, out distance)) {
					startPos = _ray.GetPoint (distance);
				}
				mode = 1;
				lineRenderer.enabled = true;
			} else if (Input.GetMouseButton (0)) {
				Ray _ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (plane.Raycast (_ray, out distance)) {
					endPos = _ray.GetPoint (distance);
				}
				mode = 2;

				//매순간생성...
				//Vector3 _size = endPos - startPos;
				//Vector3 _center = startPos + _size/2f;
				//hitBounds.SetMinMax = new Bounds (_center, _size);

				//재활용형...
				SetMinMax(ref hitMin, true, startPos, endPos);
				SetMinMax(ref hitMax, false, startPos, endPos);
				hitBounds.SetMinMax(hitMin, hitMax);
			} else if (Input.GetMouseButtonUp (0)) {
				mode = 1;

				scpObject.CheckHitObject (hitBounds);
				lineRenderer.enabled = false;
			}

			if (mode == 2) {
				posArea [0].Set(startPos.x, startPos.y, startPos.z);
				posArea [1].Set(startPos.x, endPos.y, startPos.z);
				posArea [2].Set(endPos.x, endPos.y, startPos.z);
				posArea [3].Set(endPos.x, startPos.y, startPos.z);
				posArea [4].Set(startPos.x, startPos.y, startPos.z);
				lineRenderer.SetPositions (posArea);

				Gizmos2.DebugBounds (hitBounds, Color.green);
			}
		}


		void SetMinMax(ref Vector3 _rtn, bool _bMin, Vector3 _p1, Vector3 _p2){
			if (_bMin) {
				_rtn.Set (
					(_p1.x < _p2.x) ? _p1.x : _p2.x,
					(_p1.y < _p2.y) ? _p1.y : _p2.y,
					(_p1.z < _p2.z) ? _p1.z : _p2.z
				);
			} else {
				_rtn.Set (
					(_p1.x > _p2.x) ? _p1.x : _p2.x,
					(_p1.y > _p2.y) ? _p1.y : _p2.y,
					(_p1.z > _p2.z) ? _p1.z : _p2.z
				);
			}
		}
	}
}
