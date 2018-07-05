using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardAngle2 : MonoBehaviour {
	public float speedMove = 2f;
	public float speedTurn = 180f;
	public Vector3[] localPos;
	Vector3[] worldPos;
	int index;
	Transform trans;
	Vector3 nextPoint;
	Quaternion nextRotation;
	public Color lineColor = Color.green;

	// Use this for initialization
	void Start () {
		trans = transform;
		worldPos = new Vector3[localPos.Length];
		for (int i = 0; i < localPos.Length; i++) {
			worldPos [i] = transform.position + localPos[i];
		}

		index = 0;
		CalNextPoint ();
	}

	void CalNextPoint(){
		nextPoint = worldPos [index];
		nextRotation = Quaternion.LookRotation (worldPos [index] - trans.position);
	}
	
	// Update is called once per frame
	void Update () {
		//move next point.
		if (trans.position == nextPoint && trans.rotation == nextRotation) {
			index++;
			if (index >= worldPos.Length) {
				index = 0;
			}
			CalNextPoint ();
		}

		//move and rotation
		trans.position = Vector3.MoveTowards (trans.position, nextPoint, speedMove * Time.deltaTime);
		trans.rotation = Quaternion.RotateTowards (trans.rotation, nextRotation, speedTurn * Time.deltaTime);
	}


	void OnDrawGizmos(){
		if (localPos != null && localPos.Length >= 2) {
			Gizmos.color = lineColor;

			//Vector pos calculate
			Vector3[] _v = new Vector3[localPos.Length];
			if (!Application.isPlaying) {				
				for (int i = 0; i < localPos.Length; i++) {
					_v [i] = localPos[i] + transform.position;
				}
			} else {
				_v = worldPos;
			}

			//2. line draw.
			Vector3 _oldPos = _v[0];
			int j = 1;
			for (; j < _v.Length; j++) {
				Gizmos.DrawLine (_oldPos, _v [j]);
				_oldPos = _v [j];
			}
			Gizmos.DrawLine (_v[0], _v [_v.Length - 1]);
		}
	}
}
