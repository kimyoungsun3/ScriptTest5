using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM2_Delegate
{
	public class CBF2 : FSMObject<CBF2.eGameState>
	{
		public enum eGameState
		{
			None, Idle, Move, Rotate 
		};
		Transform trans;
		public float moveSpeed = 1f;
		public float turnSpeed = 180f;

		float waitTime;
		Vector3 newPos;
		[SerializeField]Quaternion newRot;

		// Use this for initialization
		void Start()
		{
			trans = transform;
			AddState(eGameState.Idle,	InIdle,		ModifyIdle,		null);
			AddState(eGameState.Move,	InMove,		ModifyMove,		null);
			AddState(eGameState.Rotate, InRotate,	ModifyRotate,	null);


			MoveState(eGameState.Idle);
		}

		#region Idle start
		void InIdle()
		{
			Debug.Log("InIdle >> resource read");
			waitTime = Time.time + Random.Range(1f, 3f);
		}

		void ModifyIdle()
		{
			Debug.Log("ModifyIdle >> ");
			if (Time.time > waitTime)
			{
				MoveState(eGameState.Move);
				return;
			}
		}
		#endregion //idle end


		#region Move start
		void InMove()
		{
			Debug.Log("InMove >> resource read");
			int _where = Random.Range(0, 3);
			switch (_where)
			{
				case 0:
					newPos = trans.position + trans.forward;
					break;
				case 1:
					newPos = trans.position + trans.right;
					break;
				case 2:
					newPos = trans.position - trans.right;
					break;
			}
		}

		void ModifyMove()
		{
			Debug.Log("ModifyMove >> ");
			if (trans.position == newPos)
			{
				MoveState(eGameState.Rotate);
				return;
			}

			trans.position = Vector3.MoveTowards(trans.position, newPos, moveSpeed * Time.deltaTime);
		}
		#endregion //Move end

		#region Rotate start
		void InRotate()
		{
			Debug.Log("InRotate >> resource read");
			int _where = Random.Range(0, 2);
			switch (_where)
			{
				case 0:
					newRot = Quaternion.Euler(Vector3.up * (trans.eulerAngles.y + 90f));
					break;
				case 1:
					newRot = trans.rotation * Quaternion.Euler(Vector3.up * 90);
					break;
			}
		}

		void ModifyRotate()
		{
			Debug.Log("ModifyRotate >> resource read");

			if (trans.rotation.eulerAngles == newRot.eulerAngles)
			{
				MoveState(eGameState.Idle);
				return;
			}

			trans.rotation = Quaternion.RotateTowards(trans.rotation, newRot, turnSpeed * Time.deltaTime);

		}
		#endregion //Rotate end

	}
}
