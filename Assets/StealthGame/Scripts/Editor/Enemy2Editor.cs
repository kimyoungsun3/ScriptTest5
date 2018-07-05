using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Enemy2))]
public class Enemy2Editor : Editor {
	Enemy2 curve;
	Transform handleTransform;
	Quaternion handleRotation;

	void OnEnable(){
		curve = target as Enemy2;
		handleTransform = curve.transform;	
	}

	void OnSceneGUI(){
		if (Application.isPlaying)
			return;
		
		int _len = curve.localPoint.Length;
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
	}

	Vector3 ShowPoint(int _idx){
		Vector3 _point = handleTransform.TransformPoint(curve.localPoint[_idx]);

		EditorGUI.BeginChangeCheck ();
		_point = Handles.DoPositionHandle (_point, handleRotation);
		if (EditorGUI.EndChangeCheck ()) {
			Undo.RecordObject (curve, "Move Point");	//undo option add.
			EditorUtility.SetDirty (curve);
			curve.localPoint[_idx] = handleTransform.InverseTransformPoint (_point);
		}

		return _point;
	}
}