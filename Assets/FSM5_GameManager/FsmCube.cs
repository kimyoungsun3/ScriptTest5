﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FSM5{
	public class FsmCube : FSM<FsmCube.CubeState> {
		public enum CubeState{ None, Idle, Move, Rotate };
		public float nextPointDistance = 5f;
		public float speedMove 		= 1f;
		public float speedRotate 	= 180f;
		Vector3 nextPos;
		Quaternion nextRotation;
		float nextTime;
		float NEXT_WAIT_TIME = 1f;

		void Start () {
			AddState(CubeState.Idle, 	Init_Idle, 		Modify_Idle, 	Release_Idle);
			AddState(CubeState.Move, 	Init_Move, 		Modify_Move, 	Release_Move);
			AddState(CubeState.Rotate, 	Init_Rotate, 	Modify_Rotate,	Release_Rotate);

			MoveState (CubeState.Idle);
			gameObject.SetActive (false);
		}

		//-----------------------------------
		void Init_Idle(){
			//Debug.Log ("Init_Idle");
			nextTime = Time.time + NEXT_WAIT_TIME;
		}

		void Modify_Idle(){
			if (Time.time > nextTime) {
				MoveState (CubeState.Move);
				return;
			}
		}

		void Release_Idle(){
			//Debug.Log ("ReleaseIdle");
		}

		//-----------------------------------
		void Init_Move(){
			nextPos = transform.position + transform.forward * nextPointDistance;
		}

		void Modify_Move(){
			if (transform.position == nextPos) {
				MoveState (CubeState.Rotate);
				return;
			}
			transform.position = Vector3.MoveTowards (transform.position, nextPos, speedMove * Time.deltaTime );
		}

		void Release_Move(){
			//Debug.Log ("Release_Move");
		}

		//-----------------------
		void Init_Rotate(){
			//Debug.Log ("InitRotate");
			nextRotation = transform.rotation * Quaternion.Euler (Vector3.up * 90);
		}

		void Modify_Rotate(){
			if (transform.rotation == nextRotation) {
				MoveState (CubeState.Idle);
				return;
			}
			//Debug.Log (" > Rotate State");
			transform.rotation = Quaternion.RotateTowards (transform.rotation, nextRotation, speedRotate * Time.deltaTime );
		}

		void Release_Rotate(){
			//Debug.Log ("Release_Move");
		}
	}
}