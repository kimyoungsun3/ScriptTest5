using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour {
	public Vector3[] points = new Vector3[0];

	//public void Reset(){
	//	points = new Vector3[] {
	//		new Vector3 (1f, 0, 0),
	//		new Vector3 (2f, 0, 0),
	//		new Vector3 (3f, 0, 0),
	//	};
	//}

	public Vector3 GetPoint(float _t){
		return transform.TransformPoint (Bezier.GetPoint (points [0], points [0 + 1], points [0 + 2], points [0 + 3], _t));
	}

	public Vector3 GetVelocity(float _t){
		return transform.TransformPoint(Bezier.GetFirstDerivative(points [0], points [0 + 1], points [0 + 2], points [0 + 3], _t)) - transform.position;
	}

	public Vector3 GetDirection(float _t){

		return GetVelocity (_t).normalized;
	}
}
