using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM5;

namespace StealthGame2
{
	public class Enemy : FSM<Enemy.eEnemyState>
	{
		public enum eEnemyState {
			None, Idle, Move, Rotate, Wait, Chase
		};

		public Vector3[] localPoint = new Vector3[0];
		Vector3[] wayPoint = new Vector3[0];
		public float speedMove = 2f;
		Vector3 nextPoint;
		Quaternion nextDirQ;
		int nextPointIndex;

		public float speedRotate = 90f;
		[SerializeField] float WAIT_TIME = 0.2f;
		float nextTime;
		public float searchTime = 0.5f;
		//public float viewAngle = 60f;

		public LayerMask maskFind;
		public LayerMask maskBlock;
		public QueryTriggerInteraction queryTrigger;

		//내부 변수들....
		Light light;
		Transform targeting = null;
		Transform trans;
		//Vector3 dir;


		// Use this for initialization
		void Start()
		{
			Init();
			AddState(eEnemyState.Idle,		Init_Idle,		Modify_Idle,	null);
			AddState(eEnemyState.Move,		Init_Move,		Modify_Move,	null);
			AddState(eEnemyState.Rotate,	Init_Rotate,	Modify_Rotate,	null);
			AddState(eEnemyState.Wait,		Init_Wait,		Modify_Wait,	null);
			AddState(eEnemyState.Chase,		Init_Chase,		Modify_Chase,	null);

			MoveState(eEnemyState.Move);
		}

		void Init()
		{
			//light, wayPoint <- localPoint
			trans = transform;
			light = GetComponentInChildren<Light>();
			wayPoint = new Vector3[localPoint.Length];
			for(int i = 0, _len = localPoint.Length; i < _len; i++)
			{
				wayPoint[i] = trans.position + localPoint[i];
			}
		}

		#region idle
		void Init_Idle()
		{

		}
		void Modify_Idle()
		{

		}
		#endregion //idle

		#region Move
		void Init_Move()
		{
			nextPoint = wayPoint[nextPointIndex];
		}

		void Modify_Move()
		{
			trans.position = Vector3.MoveTowards(trans.position, nextPoint, speedMove * Time.deltaTime);
			if(trans.position == nextPoint)
			{
				nextPointIndex	= (nextPointIndex + 1) % wayPoint.Length;
				nextPoint		= wayPoint[nextPointIndex];

				//wait...
				MoveState(eEnemyState.Wait);
			}
		}
		#endregion


		#region Wait
		void Init_Wait()
		{
			nextTime = Time.time + WAIT_TIME;
		}
		void Modify_Wait()
		{
			if(Time.time > nextTime)
			{
				MoveState(eEnemyState.Rotate);
				return;
			}
		}
		#endregion

		#region Rotate
		void Init_Rotate()
		{
			nextDirQ = Quaternion.LookRotation(nextPoint - trans.position);
		}

		void Modify_Rotate()
		{
			if(trans.rotation == nextDirQ)
			{
				MoveState(eEnemyState.Move);
				return;
			}

			trans.rotation = Quaternion.RotateTowards(trans.rotation, nextDirQ, speedRotate * Time.deltaTime);
		}
		#endregion

		#region Chase
		void Init_Chase()
		{

		}

		void Modify_Chase()
		{
			if(targeting == null)
			{
				MoveState(eEnemyState.Move);
				return;
			}
			Debug.DrawLine(trans.position, targeting.position, Color.red);

			//회전과 이동...
			Quaternion _dirQ = Quaternion.LookRotation(targeting.position - trans.position);
			trans.rotation = Quaternion.Lerp(trans.rotation, _dirQ, 0.2f * Time.deltaTime);
			trans.Translate(Vector3.forward * speedMove * Time.deltaTime);
		}
		#endregion

		private void OnDrawGizmos()
		{
			if (localPoint.Length <= 0) return;

			Vector3 _startPos, _prePos, _pos;
			_startPos = Application.isPlaying?wayPoint[0]:(transform.position + localPoint[0]);
			_prePos = _startPos;
			for (int i = 0; i < localPoint.Length; i++)
			{
				_pos = Application.isPlaying ? wayPoint[i] : (transform.position + localPoint[i]);
				Gizmos.color = Color.yellow;
				Gizmos.DrawSphere(_pos, .2f);
				Gizmos.DrawLine(_prePos, _pos);

				_prePos = _pos;
			}
			Gizmos.DrawLine(_prePos, _startPos);

			//view direction
			Debug.DrawRay(transform.position, transform.right, Color.red);
			Debug.DrawRay(transform.position, transform.up, Color.green);
			Debug.DrawRay(transform.position, transform.forward, Color.blue);

			//시아각...
			Light _light = Application.isPlaying ? light : GetComponentInChildren<Light>();
			float _range = _light.range;
			float _viewAngle = _light.spotAngle;
			Quaternion _q1 = Quaternion.Euler(Vector3.up * (transform.eulerAngles.y - _viewAngle / 2));
			Quaternion _q2 = Quaternion.Euler(Vector3.up * (transform.eulerAngles.y + _viewAngle / 2));
			Debug.DrawLine(transform.position, transform.position + _q1 * Vector3.forward * _range, Color.gray);
			Debug.DrawLine(transform.position, transform.position + _q2 * Vector3.forward * _range, Color.gray);
		}
	}
}
