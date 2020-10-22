using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace FieldOfViewTest
{
	[CustomEditor(typeof(FieldOfView))]
	public class FieldOfViewEditor : Editor
	{
		private void OnSceneGUI()
		{
			FieldOfView _fow	= (FieldOfView)target;
			Transform _t		= _fow.transform;

			//큰원...
			Handles.color = Color.white;
			Handles.DrawWireArc(_t.position, Vector3.up, Vector3.forward, 360f, _fow.viewRadius);

			//Left, Right see
			Vector3 _viewLeft	= _fow.GetDirFromAngle(-_fow.viewAngle * 0.5f, false);
			Vector3 _viewRight	= _fow.GetDirFromAngle(+_fow.viewAngle * 0.5f, false);
			Handles.DrawLine(_t.position, _t.position + _viewLeft * _fow.viewRadius);
			Handles.DrawLine(_t.position, _t.position + _viewRight * _fow.viewRadius);

			//Target Line
			List<Transform> _list = _fow.listTarget;
			Handles.color = Color.red;
			for (int i = 0, _count = _list.Count; i < _count; i++)
			{
				Handles.DrawLine(_t.position, _list[i].position);
			}
		}
	}
}