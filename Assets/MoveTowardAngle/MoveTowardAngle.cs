using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardAngle : MonoBehaviour {
	public float speedMove = 2f;
	public float speedTurn = 180f;
	public Vector3[] localPoints;
	Vector3[] worldPoints;
	Transform trans;
	Vector3 nextPoint;
	int index;
	Quaternion nextRotation;
	public Color lineColor = Color.green;

	void Start(){
		trans = transform;
		worldPoints = new Vector3[localPoints.Length];
		for (int i = 0; i < localPoints.Length; i++) {
			worldPoints [i] = trans.position + localPoints [i];
		}

		index = 0;
		CalculateNextPoint ();
	}

	void Update () {
		//nextRotation = (nextPoint != trans.position)?Quaternion.LookRotation(nextPoint - trans.position):nextRotation;

		if (trans.position == nextPoint) {
			if (trans.rotation == nextRotation) {
				index = (index + 1) % worldPoints.Length;
				CalculateNextPoint ();
			}
		}

		trans.position = Vector3.MoveTowards (trans.position, nextPoint, speedMove * Time.deltaTime);

		//mytran.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);	//움직임 이상함...
		trans.rotation = Quaternion.RotateTowards(trans.rotation, nextRotation, speedTurn * Time.deltaTime);
	}

	void CalculateNextPoint(){
		nextPoint 		= worldPoints [index];
		nextRotation 	= Quaternion.LookRotation (nextPoint - trans.position);
	}

	void OnDrawGizmos(){
		if (localPoints != null && localPoints.Length >= 2) {
			Gizmos.color = lineColor;

			//Vector pos calculate
			Vector3[] _v = new Vector3[localPoints.Length];
			if (!Application.isPlaying) {				
				for (int i = 0; i < localPoints.Length; i++) {
					_v [i] = localPoints[i] + transform.position;
				}
			} else {
				_v = worldPoints;
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
