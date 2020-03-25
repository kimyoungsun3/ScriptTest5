using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace StealthGame2 { 
	[CustomEditor(typeof(Enemy))]
	public class EnemyEditor : Editor {
		Enemy enemy;
		Transform handleTransform;
		Quaternion handleRotation;

		private void OnEnable()
		{
			enemy				= target as Enemy;
			handleTransform = enemy.transform;
		}

		private void OnSceneGUI()
		{
			if (Application.isPlaying)return;

			int _len = enemy.localPoint.Length;
			if (_len <= 0) return;

			handleRotation = Tools.pivotRotation == PivotRotation.Local ? handleTransform.rotation : Quaternion.identity;

			//local point -> world point
			Vector3[] _points = new Vector3[_len];
			for(int i = 0; i < _len; i++)
			{
				_points[i] = ShowPoint(i);
			}

			//draw line
			Handles.color = Color.gray;
			for(int i = 0; i < _len -  1; i++)
			{
				Handles.DrawLine(_points[i], _points[i + 1]);
			}
			Handles.DrawLine(_points[0], _points[_len - 1]);
		}

		Vector3 ShowPoint(int _idx)
		{
			Vector3 _point = handleTransform.TransformPoint(enemy.localPoint[_idx]);

			EditorGUI.BeginChangeCheck();
			_point = Handles.DoPositionHandle(_point, handleRotation);
			if (EditorGUI.EndChangeCheck())
			{
				Undo.RecordObject(enemy, "Move Point");
				EditorUtility.SetDirty(enemy);
				enemy.localPoint[_idx] = handleTransform.InverseTransformPoint(_point);
			}
			return _point;
		}
	}
}
