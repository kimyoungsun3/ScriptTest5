using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolManager5;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DMapJump
{
	public class PlayerControllerAuto : MonoBehaviour
	{
		//public static PlayerControllerAuto ins;
		public Transform spawnPoint;
		public float WAIT_TIME = 0.05f;
		float waitTime;

		//float v, h;
		Vector3 move;//, hitPoint, 
		Vector3 dirView;
		Transform trans;
		public float speed;
		//Plane plane;
		//Ray ray;
		//Camera cam;
		float distance;
		public float gunAngleStep = 5f;
		[Range(1, 10)] public int gunCount = 1;

		UIJoyStick uiJoyStick;
		Vector2 MIN, MAX;

		//private void Awake()
		//{
		//	ins = this;
		//}

		private void Start()
		{
			//plane		= new Plane(Vector3.back, Vector3.zero);
			//cam		= Camera.main;
			trans		= transform;
			uiJoyStick	= UIJoyStick.ins;

			Camera _c = Camera.main;
			float _h = _c.orthographicSize - 1f;
			float _w = _c.orthographicSize * _c.aspect - 1f;
			MIN.Set(-_w, -_h);
			MAX.Set(+_w, +_h);

			//Debug.Log(MIN + ":" + MAX);
		}

		float searchRadius = 20f;
		public LayerMask maskEnemey;
		private Transform target;
		bool SearchEnemyPosition(ref Vector3 _dir)
		{
			bool _bFind = false;
			//Debug.Log(target);
			if (target != null && target.gameObject.activeSelf)
			{
				_bFind	= true;
				_dir	= target.position - trans.position;
				//Debug.Log(target + ":" + target.gameObject.activeSelf);
				return _bFind;
			}

			//Debug.Log("maskEnemey:" + maskEnemey.value);
			Collider[] _cols = Physics.OverlapSphere(trans.position, searchRadius, maskEnemey);
			if (_cols.Length > 0)
			{
				//Debug.Log(" >> new Find");
				_bFind	= true;
				_dir	= _cols[0].transform.position - trans.position;
				target	= _cols[0].transform;
			}
			else
			{
				//Debug.Log(" >> not Find");
				//_bFind = false;
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
				if(WAIT_TIME < 0.05f)
				{
					WAIT_TIME = 0.2f;
				}
			}
		}

		private void Update()
		{
			DDD();
			//v = Input.GetAxisRaw("Vertical");
			//h = Input.GetAxisRaw("Horizontal");
			//move.Set(h, v, 0f);
			//move = move.normalized;
			//trans.Translate(move * speed * Time.deltaTime, Space.World);
			trans.Translate(uiJoyStick.moveDir * speed * Time.deltaTime, Space.World);
			Vector3 _pos = trans.position;
			_pos.x = Mathf.Clamp(_pos.x, MIN.x, MAX.x);
			_pos.y = Mathf.Clamp(_pos.y, MIN.y, MAX.y);
			trans.position = _pos;


			//ray = cam.ScreenPointToRay(Input.mousePosition);
			//if(plane.Raycast(ray, out distance))
			//{
			//	hitPoint = ray.GetPoint(distance);
			//	hitPoint.z = 0;
			//	dirView = hitPoint - trans.position;

			//	float _angleZ = Mathf.Atan2(dirView.y, dirView.x) * Mathf.Rad2Deg;
			//	trans.rotation = Quaternion.Euler(0, 0, _angleZ);
			//}


			if (Time.time > waitTime)
			{
				waitTime = Time.time + WAIT_TIME;
				//if (Input.GetMouseButton(0))
				{
					bool _bFind = SearchEnemyPosition(ref dirView);
					Debug.Log(_bFind + ":" + dirView);
					if (_bFind)
					{
						float _angleZ = Mathf.Atan2(dirView.y, dirView.x) * Mathf.Rad2Deg;
						trans.rotation = Quaternion.Euler(0, 0, _angleZ);
						Debug.Log(_angleZ + ":" + Mathf.Atan2(dirView.y, dirView.x));

						Quaternion _q;
						float _angleTotal = (gunCount - 1) * gunAngleStep;
						float _angle = Util.GetAngleFromDir(dirView) - _angleTotal / 2f;

						for (int i = 0; i < gunCount; i++)
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