using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//
[CustomEditor(typeof(BezierCurve))]
public class BezierCurveEditor : Editor {	
	BezierCurve curve;
	Transform handleTransform;
	Quaternion handleRotation;
	int lineSteps = 10;
	const float directionScale = .5f;

	void OnEnable(){
		curve = target as BezierCurve;
		handleTransform = curve.transform;	
	}

	void OnSceneGUI(){
		int _len = curve.points.Length;
		if (_len <= 0)
			return;
		handleRotation = Tools.pivotRotation == PivotRotation.Local?handleTransform.rotation:Quaternion.identity;

		//local point -> transform 하위 point
		Vector3[] _points = new Vector3[_len];
		for (int i = 0; i < _len; i++) {
			_points[i] = ShowPoint(i);
		}

		//draw line
		Handles.color = Color.gray;
		for (int i = 0; i < _len - 1; i++) {
			Handles.DrawLine (_points [i], _points [i + 1]);
		}

		ShowDirection ();
		//for (int i = 0; i < _len - 3; i++) {
		Handles.DrawBezier (
			_points [0], 
			_points [3], 
			_points [1], 
			_points [2], 
			Color.white, null, 2f);
		//}
				
	}

	void ShowDirection(){
		Handles.color = Color.green;
		Vector3 _point = curve.GetPoint (0f);
		Handles.DrawLine (_point, _point + curve.GetDirection (0f) * directionScale);
		for (int i = 1; i < lineSteps; i++) {
			_point = curve.GetPoint (i / (float)lineSteps);
			Handles.DrawLine(_point, _point + curve.GetDirection(i/(float)lineSteps) * directionScale);
		}

		//
		//Vector3 lineStart = curve.GetPoint (0f);
		//Vector3 lineEnd;
		//Handles.color = Color.green;
		//Handles.DrawLine(lineStart, lineStart + curve.GetDirection(0f));
		//for (int i = 1; i <= lineSteps; i++) {
		//	lineEnd = curve.GetPoint (i / (float)lineSteps);
		//	Handles.color = Color.white;
		//	Handles.DrawLine (lineStart, lineEnd);
		//	Handles.color = Color.green;
		//	Handles.DrawLine(lineEnd, lineEnd + curve.GetDirection(i / (float)lineSteps));
		//	lineStart = lineEnd;
		//}
	}


	Vector3 ShowPoint(int _idx){
		Vector3 _point = handleTransform.TransformPoint(curve.points[_idx]);

		EditorGUI.BeginChangeCheck ();
		_point = Handles.DoPositionHandle (_point, handleRotation);
		if (EditorGUI.EndChangeCheck ()) {
			Undo.RecordObject (curve, "Move Point");	//undo option add.
			EditorUtility.SetDirty (curve);
			curve.points[_idx] = handleTransform.InverseTransformPoint (_point);
		}

		return _point;
	}
}
