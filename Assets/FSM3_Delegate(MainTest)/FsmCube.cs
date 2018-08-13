using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FSM3_Delegate{
	public class FsmCube : Fsm<FsmCube.CubeState> {
		public enum CubeState{ None, Idle, Move, Rotate };
		public float speedMove = 1f;
		public float speedRotate = 20f;
		int index;
		Vector3[] pos = new Vector3[2]{
			new Vector3(-1, 0, 0), new Vector3(1, 0, 0)
		};
		Vector3 targetPos;

		void Start () {
			AddState(CubeState.Idle, 	InitIdle, 	ReleaseIdle);
			AddState(CubeState.Move, 	InitMove, 	null);
			AddState(CubeState.Rotate, 	InitRotate, null);

			MoveState (CubeState.Idle);
		}

		void Update(){
			
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				MoveState (CubeState.Idle);
			} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
				MoveState (CubeState.Move);
			} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
				MoveState (CubeState.Rotate);
			}

			switch (curState) {
			case CubeState.Idle:
				break;
			case CubeState.Move:
				if (transform.position == pos [index]) {
					index = (index + 1) % pos.Length;
					targetPos = pos [index];
				}
				transform.position = Vector3.MoveTowards (transform.position, targetPos, speedMove * Time.deltaTime);
				break;
			case CubeState.Rotate:
				transform.Rotate (Vector3.up * speedRotate * Time.deltaTime);
				break;
			}
		}

		void InitIdle(){
			Debug.Log ("InitIdle");
		}

		void ReleaseIdle(){
			Debug.Log ("ReleaseIdle");
		}

		void InitMove(){
			index = 0;
			targetPos = pos [index];
			Debug.Log ("InitMove");
		}

		void InitRotate(){
			Debug.Log ("InitRotate");
		}

	}
}