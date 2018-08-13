using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FSM4_Delegate{
	public class FSMCubeAuto : FSMAutoUpdate<FSMCubeAuto.STATE> {
		public enum STATE{
			None, Move, Rotate, Wait
		};

		Transform trans;
		Vector3  newPos;
		Quaternion  newQ;
		public float moveSpeed = 1f;
		public float turnSpeed = 180f;

		void Start () {
			trans = transform;		
			AddState (STATE.Move, 	pInMove, 	modifyMove, 	null);
			AddState (STATE.Rotate, pInRotate, 	modifyRotate, 	null);
			AddState (STATE.Wait,	pInWait, 	modifyWait, 	null);

			MoveState (STATE.Move);
		}

		//-----------------------------
		//Move
		//-----------------------------
		void pInMove(){
			//oldPos = trans.position;
			newPos = trans.position + Vector3.right;
		}

		void modifyMove(){
			if (trans.position == newPos) {
				MoveState (STATE.Rotate);
				return;
			}
			trans.position = Vector3.MoveTowards (trans.position, newPos, moveSpeed * Time.deltaTime);
		}

		//-----------------------------
		//Rotate
		//-----------------------------
		void pInRotate(){
			//oldQ = trans.rotation;
			newQ = trans.rotation * Quaternion.Euler (Vector3.up * 90f);

			//Debug.Log (trans.rotation + ":" + newQ);
		}

		void modifyRotate(){
			if (trans.rotation == newQ) {
				MoveState (STATE.Wait);
				return;
			}

			trans.rotation = Quaternion.RotateTowards (trans.rotation, newQ, turnSpeed * Time.deltaTime);
		}

		//-----------------------------
		//Wait
		//-----------------------------
		float waitNextTime;
		void pInWait(){
			waitNextTime = Time.time + 1f;
		}

		void modifyWait(){
			if (Time.time > waitNextTime) {
				MoveState (STATE.Move);
				return;
			}
		}
	}
}