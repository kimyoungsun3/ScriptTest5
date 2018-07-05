using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorCrossTest : MonoBehaviour {
	public Transform targetA, targetB;
	public Transform camera;
	Vector3 dir, pos, crossDir;
	[Range(0, 1)]public float interpolate = .5f;
	public float DISTANCE = 5f;

	void Start () {
		
	}
	
	void Update () {
		dir = targetB.position - targetA.position;
		pos = Vector3.Lerp (targetA.position, targetB.position, interpolate);
		crossDir = Vector3.Cross (dir, Vector3.up).normalized;

		//Camera Position
		camera.position = pos - crossDir * DISTANCE;
		camera.LookAt (pos);

		//Debug Line
		Debug.DrawLine(targetA.position, targetB.position, Color.red);
		Debug.DrawRay (pos, crossDir, Color.blue);

		/*
		dir = targetB.position - targetA.position;
		pos = Vector3.Lerp (targetA.position, targetB.position, interpolate);

		crossDir = Vector3.Cross (dir, Constant.V3_UP);
		crossDir = crossDir.normalized;

		camera.position = pos - crossDir * DISTANCE;
		camera.LookAt (pos);

		Debug.DrawLine (targetA.position, targetB.position, Color.white);
		Debug.DrawRay (pos, dir, Color.blue);
		*/
	}
}
