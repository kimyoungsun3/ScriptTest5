using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace FindOfView
{
	[CustomEditor(typeof(FieldOfView6_Enemy))]
	public class FieldOfView6_EnemyEditor : Editor
	{
		FieldOfView6_Enemy enemy;
		Transform enemyTrans;
		Quaternion enemyRot;
		Vector3[] localPoint;

		private void OnEnable()
		{
			enemy = target as FieldOfView6_Enemy;
			enemyTrans = enemy.transform;
		}

		private void OnSceneGUI()
		{
			if (Application.isPlaying) return;

			localPoint = enemy.enemyData.localPoint;
			int _len = localPoint.Length;
			if (_len <= 0) return;
			enemyRot = Tools.pivotRotation == PivotRotation.Local ? enemyTrans.rotation : Quaternion.identity;

			Vector3[] _worldPoint = new Vector3[_len];
			for (int i = 0; i < _len; i++)
			{
				_worldPoint[i] = ShowPoint(i);
			}

			Handles.color = Color.gray;
			for(int i = 0; i < _len - 1; i++)
			{
				Handles.DrawLine(_worldPoint[i], _worldPoint[i + 1]);
			}
		}

		Vector3 ShowPoint(int _idx)
		{
			//Vector3 _wp = enemyTrans.TransformPoint(localPoint[_idx]);
			Vector3 _wp = enemyTrans.position + localPoint[_idx];

			EditorGUI.BeginChangeCheck();
			_wp = Handles.DoPositionHandle(_wp, enemyRot);
			if (EditorGUI.EndChangeCheck())
			{
				Undo.RecordObject(enemy, "Move Point");
				EditorUtility.SetDirty(enemy);
				//localPoint[_idx] = enemyTrans.InverseTransformPoint(_wp);
				localPoint[_idx] = _wp - enemyTrans.position;
			}

			return _wp;
		}
	}
}