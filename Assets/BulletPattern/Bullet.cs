using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolManager5;

namespace BulletPattern{
	public class Bullet : MonoBehaviour {
		Transform trans;
		Transform target;

		[SerializeField] BulletType type;
		[SerializeField] float speed 	= 1f;
		[SerializeField] float speed1 	= 1f;
		[SerializeField] float speed2 	= 1f;
		[SerializeField] float waitTime1 	= 0;
		[SerializeField] float waitTime2 	= 0;
		[SerializeField] float waitMissleTime= 0;
		[SerializeField] float duringTime 	= 0;
		[SerializeField] float missileTime 	= 0;
		[SerializeField] float missileTurnSpeed= 1;

		void Start () {
			trans = transform;
		}

		public void SetInfo(Transform _target, BulletType _type, float _delay, float _speed1, float _duringTime, float _speed2, float _missileTime, float _missileTurnSpeed){
			target 		= _target;
			type 		= _type;

			waitTime1 	= Time.time + _delay;
			speed1 		= _speed1;
			waitTime2 	= waitTime1 + _duringTime;
			speed2 		= _speed2;

			duringTime 	= _duringTime;
			speed 		= speed1;

			missileTime = _missileTime;
			waitMissleTime= waitTime1 + _missileTime;
			missileTurnSpeed = _missileTurnSpeed;
		}


		void Update () {
			if (Time.time <= waitTime1) {
				return;
			}


			switch (type) {
			case BulletType.Normal:
				{
					trans.Translate (Vector3.right * speed * Time.deltaTime);
				}
				break;
			case BulletType.SpeedChange:
				{
					float _intervel = (Time.time - waitTime2) / duringTime;
					speed = Mathf.Lerp (speed1, speed2, _intervel);
					trans.Translate (Vector3.right * speed * Time.deltaTime);
				}
				break;
			case BulletType.Missile:
				{					
					if(Time.time > waitTime1 && Time.time < waitMissleTime){
						float _angle = Util.GetAngleFromDir (target.position - trans.position);
						Quaternion _q = Quaternion.Euler (Constant.V3_FORWARD * _angle);
						//Debug.Log (_angle + ":" + _q);

						//trans.rotation = _q;
						trans.rotation = Quaternion.Lerp (trans.rotation, _q, Time.deltaTime);
					}
					trans.Translate (Constant.V3_RIGHT * speed * Time.deltaTime);
				}
				break;
			}			
		}

		//-----------------------------------------------
		void OnDrawGizmos(){
			Gizmos.color = Color.red;
			Gizmos.DrawRay (transform.position, transform.right);
			Gizmos.color = Color.green;
			Gizmos.DrawRay (transform.position, transform.up);
		}
	}
}
