using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM2_Delegate{
	public class CBF : FSMObject<CBF.CBSTATE> {
		public enum CBSTATE{
			None, Move, Rotate, Wait, Scale
		};
		Transform trans;
		Vector3  newPos;
		Quaternion  newQ;
		public float moveSpeed = 1f;
		public float turnSpeed = 180f;

		void Start () {
			trans = transform;		
			AddState (CBSTATE.Move, 	pInMove, 	modifyMove, 	null);
			AddState (CBSTATE.Rotate, 	pInRotate, 	modifyRotate, 	null);
			AddState (CBSTATE.Wait,		pInWait, 	modifyWait, 	null);
			AddState(CBSTATE.Scale,		pInScale,	modifyScale,	null);

			MoveState (CBSTATE.Move);
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
				MoveState (CBSTATE.Rotate);
				return;
			}
			trans.position = Vector3.MoveTowards (trans.position, newPos, moveSpeed * Time.deltaTime);
		}

		//-----------------------------
		//Rotate
		//-----------------------------
		void pInRotate(){
			//oldQ = trans.rotation;
			newQ = trans.rotation * Quaternion.Euler (Vector3.up * 90);

			//Debug.Log (trans.rotation + ":" + newQ);
		}

		void modifyRotate(){
			if (trans.rotation == newQ) {
				MoveState (CBSTATE.Wait);
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
				MoveState (CBSTATE.Scale);
				return;
			}
		}
		//-----------------------------
		//Scale
		//-----------------------------
		int dir;
		float speed;
		void pInScale()
		{
			dir = Random.Range(0, 2);
			speed = 0f;
		}

		void modifyScale()
		{
			if (speed > 1f)
			{
				MoveState(CBSTATE.Move);
				return;
			}

			speed += Time.deltaTime;
			switch (dir)
			{
				case 0:
					trans.localScale = Vector3.Lerp(Vector3.one, Vector3.one / 2f, speed);
					break;
				case 1:
					trans.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 2f, speed);
					break;
			}
		}
	}
}