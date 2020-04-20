using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace Water2DSuface
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(Water2DReflect))]
	public class Water2DReflectEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			Water2DReflect _scp = target as Water2DReflect;
			if(GUILayout.Button("Setting Under Sprite"))
			{
				_scp.Editor_MakeUnderWater();
			}
		}
	}
}