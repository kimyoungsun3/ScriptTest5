using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolManager5;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DMapJump
{
	public class PlayerControllerAuto2 : MonoBehaviour
	{
		public Transform spawnPoint;
		public float WAIT_TIME = 0.05f;
		float waitTime;

		Vector3 move, dirView;
		Transform trans;
		public float speed;

		float distance;
		public float gunAngleStep = 5f;
		[Range(1, 10)] public int gunCount = 1;

		Joystick_NGUI2.NGUIJoyStick uiJoyStick;
		Vector2 MIN, MAX;

		private void Start()
		{
			trans		= transform;
			uiJoyStick	= Joystick_NGUI2.NGUIJoyStick.ins;

			Camera _c = Camera.main;
			float _h = _c.orthographicSize - 1f;
			float _w = _c.orthographicSize * _c.aspect - 1f;
			MIN.Set(-_w, -_h);
			MAX.Set(+_w, +_h);
			//Debug.Log(_w + ":" + _h);
		}

		float searchRadius = 20f;
		public LayerMask maskEnemy;
		private Transform target;
		bool SearchEnemyPosition(ref Vector3 _dir)
		{
			bool _bFind = false;
			if (target != null && target.gameObject.activeSelf)
			{
				_bFind	= true;
				_dir	= target.position - trans.position;
				return _bFind;
			}

			Collider[] _cols = Physics.OverlapSphere(trans.position, searchRadius, maskEnemy);
			if (_cols.Length > 0)
			{
				_bFind	= true;
				target	= _cols[0].transform;
				_dir	= target.position - trans.position;
			}
			else
			{
				//_bFind	= false;
				_dir	= Vector3.zero;
				target	= null;
			}
			return _bFind;
		}

		void DDD()
		{
			if (Input.GetMouseButtonDown(1))
			{
				gunCount = (gunCount + 1) % 10;
				if (gunCount <= 0)
					gunCount = 1;

				WAIT_TIME -= 0.02f;
				if (WAIT_TIME < 0.05f)
					WAIT_TIME = 0.2f;
			}
		}

		private void Update()
		{
			DDD();

			trans.Translate(uiJoyStick.moveDir * speed * Time.deltaTime, Space.World);

			Vector3 _pos = trans.position;
			_pos.x = Mathf.Clamp(_pos.x, MIN.x, MAX.x);
			_pos.y = Mathf.Clamp(_pos.y, MIN.y, MAX.y);
			trans.position = _pos;

			if (Time.time > waitTime)
			{
				waitTime = Time.time + WAIT_TIME;
				{
					bool _bFind = SearchEnemyPosition(ref dirView);
					//Debug.Log(_bFind + ":" + dirView);
					if (_bFind)
					{
						float _angleZ = Mathf.Atan2(dirView.y, dirView.x) * Mathf.Rad2Deg;
						trans.rotation = Quaternion.Euler(0, 0, _angleZ);

						//Debug.Log(_angleZ + ":" + Mathf.Atan2(dirView.y, dirView.x));
						Quaternion _q;
						float _angleTotal = (gunCount - 1) * gunAngleStep;
						float _angle = _angleZ - _angleTotal / 2f;

						for(int i = 0; i < gunCount; i++)
						{
							_q = Quaternion.Euler(0, 0, _angle);
							_angle += gunAngleStep;

							PoolManager.ins.Instantiate("PlayerBullet", spawnPoint.position, _q);
						}
					}
				}
			}
		}
	}
}