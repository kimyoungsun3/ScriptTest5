using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StructTest))]
public class StructTestEditor : Editor {

	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();

		StructTest _scp = target as StructTest;
		_scp.InitData ();
	}
}
