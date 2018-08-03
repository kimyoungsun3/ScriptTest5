using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KinematicArrow2{
	public class ArrowMove : MonoBehaviour {
		public Transform target;
		public float h = 25f;
		public float gravity = -18f;

		void Start(){
			CoShooting ();
		}

		public void CoShooting(){
			StopAllCoroutines ();
			StartCoroutine (Co_Shooting ());	
		}

		IEnumerator Co_Shooting(){
			StructInitData _data 	= CalculateInitVelocityData ();
			Vector3 _velocity 		= _data.initVelocity;
			float _time 			= Time.time + _data.time;
			//Debug.Log (_velocity + ":" + _data.time);
			Vector3 _beforePos		= transform.position;

			while(Time.time < _time){
				//move (gravity + initialVelocity)
				_velocity += gravity * Time.deltaTime * Vector3.up;				//velocity += deltaVelocity
				transform.Translate (_velocity * Time.deltaTime, Space.World);	//move

				//rotation
				transform.rotation = Util.GetQuaternionFromDir2D (transform.position - _beforePos);
				_beforePos = transform.position;
				yield return null;
			}
		}

		//-------------------------------------------------------
		// 아래의 식은 물리 공식에 입각한 식이다...
		//-------------------------------------------------------
		StructInitData CalculateInitVelocityData(){
			float _pY = target.position.y - transform.position.y;
			Vector3 _pXZ = target.position - transform.position;
			_pXZ.y = 0;
			//Debug.Log ("pY:" + _pY + " pXZ:" + _pXZ);

			float _timeRight= (Mathf.Sqrt ((-2f * h) / gravity) + Mathf.Sqrt (2f * (_pY - h) / gravity));
			Vector3 _uUp 	= Mathf.Sqrt (-2f * gravity * h) * Vector3.up;
			Vector3 _uRight = _pXZ / _timeRight;
			//Debug.Log ( "_timeRight:" + _timeRight + " _uUp:" + _uUp  " _uRight:" + _uRight );

			Vector3 _velocity = _uUp + _uRight;
			return new StructInitData(_velocity, _timeRight);
		}

		struct StructInitData{
			public readonly Vector3 initVelocity;
			public readonly float time;
			public StructInitData(Vector3 _v, float _t){
				initVelocity = _v;
				time = _t;
			}
		}
	}
}
