using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SoundManager8
{
	[CustomEditor(typeof(SoundManager))]
	public class SoundManagerEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			SoundManager _scp = target as SoundManager;
			if (GUILayout.Button("어떻게 생성되는가 보자.."))
			{
				_scp.Init();
			}
		}
	}
}