using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace NGUI_108_ButtonParticlle
{
	[CustomEditor(typeof(UIWayPoint))]
	public class UIWayPointEditor : Editor
	{
		UIWayPoint scp;

		private void OnEnable()
		{
			scp = (UIWayPoint)target;
		}

		private void OnSceneGUI()
		{
			if (!scp.bHandle) return;
			Transform _trans	= scp.transform;
			List<Vector3> _wpl	= scp.wayPointsLocal;
			
			Vector3 _pos;
			for (int i = 0, imax = _wpl.Count; i < imax; i++)
			{
				_pos = _trans.TransformPoint(_wpl[i]);
				Handles.Label(_pos, "P" + i);
				EditorGUI.BeginChangeCheck();
				_pos = Handles.PositionHandle(_pos, Quaternion.identity);
				if (EditorGUI.EndChangeCheck())
				{
					Undo.RecordObject(scp, "Move");
					EditorUtility.SetDirty(scp);
					_wpl[i] = _trans.InverseTransformPoint(_pos);					
				}		
			}
		}
	}
}