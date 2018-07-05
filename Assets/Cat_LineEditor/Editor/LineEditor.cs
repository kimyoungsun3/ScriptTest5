using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Line))]
public class LineEditor : Editor {
	Line line;

	//public override void OnInspectorGUI(){
	//	DrawDefaultInspector ();
	//}

	void OnSceneGUI(){
		line = target as Line;
		Transform _tran = line.transform;
		//local mode / world mode
		Quaternion _rot = Tools.pivotRotation == PivotRotation.Local?_tran.rotation:Quaternion.identity;

		//position(O), rotation(O), px rotation(O)
		Vector3 _p1 = _tran.TransformPoint(line.p1);
		Vector3 _p2 = _tran.TransformPoint(line.p2);

		Handles.color = Color.white;
		Handles.DrawLine (_p1, _p2);			//line 그르기...

		EditorGUI.BeginChangeCheck ();
		_p1 = Handles.DoPositionHandle (_p1, _rot);	//position point 등장....
		if (EditorGUI.EndChangeCheck ()) {
			Undo.RecordObject (line, "Move Point");	//undo option add.
			EditorUtility.SetDirty (line);
			line.p1 = _tran.InverseTransformPoint (_p1);
		}

		EditorGUI.BeginChangeCheck ();
		_p2 = Handles.DoPositionHandle (_p2, _rot);	//position point 등장....
		if (EditorGUI.EndChangeCheck ()) {
			Undo.RecordObject (line, "Move Point");	//undo option add.
			EditorUtility.SetDirty (line);
			line.p2 = _tran.InverseTransformPoint (_p2);
		}

		/*
		//position(O), rotation(O), px rotation(X)
		//Vector3 _p1 = _tran.TransformPoint(line.p1);
		//Vector3 _p2 = _tran.TransformPoint(line.p2);

		Handles.color = Color.white;
		Handles.DrawLine (_p1, _p2);
		*/

		/*
		//position(O), rotation(X), px rotation(X)
		Vector3 _p1 = _tran.position + line.p1;
		Vector3 _p2 = _tran.position + line.p2;

		Handles.color = Color.white;
		Handles.DrawLine (_p1, _p2);
		*/
		
		
	}
}
