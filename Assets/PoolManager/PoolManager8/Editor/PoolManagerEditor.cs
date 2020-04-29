using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace PoolManager8
{
	[CustomEditor(typeof(PoolManager))]
	public class PoolManagerEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			PoolManager _scp = target as PoolManager;
			if (GUILayout.Button("이름넣어주기"))
			{
				_scp.Editor_CreateName();
			}
		}
	}
}