using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FindOfView
{
	public class FieldOfView4 : MonoBehaviour
	{
		Transform trans;
		[SerializeField] float angleMax = 60f;
		[SerializeField] float radius = 3f;
		[SerializeField] LayerMask maskFind, maskBlock;
		[SerializeField] float SEARCH_TIME = 0.5f;
		float searchTime;
		[SerializeField] List<Transform> targetList = new List<Transform>();

		// Use this for initialization
		void Start()
		{
			trans = transform;

		}


		// Update is called once per frame
		void Update()
		{
			//일정 주기로 검색한다...
			FindEnemy();

			DisplayEnemy();
		}

		void FindEnemy()
		{
			if (Time.time > searchTime)
			{
				searchTime = Time.time + SEARCH_TIME;

				Transform _target;
				float _angleMaxHalf = angleMax * .5f;
				float _angle, _distance;

				//1. 충돌체 검사...
				Collider[] _cols = Physics.OverlapSphere(trans.position, radius, maskFind);
				Vector3 _pos = trans.position;
				Vector3 _dir;
				targetList.Clear();
				RaycastHit _hit;
				for (int i = 0, _len = _cols.Length; i < _len; i++)
				{
					_target = _cols[i].transform;
					_dir	= _target.position - _pos;

					//2. 시아내인가???...
					_angle = Vector3.Angle(trans.forward, _dir);
					if (_angle <= _angleMaxHalf)
					{
						_distance = _dir.magnitude;
						//3. 사이에 어떤 오브젝트가 있다면....
						if (Physics.Raycast(trans.position, _dir, out _hit, _distance))
						{
							//Debug.Log(_target.name + ":" + _hit.transform.name);
							if(_target == _hit.transform)
							{
								targetList.Add(_target);
							}
						}
					}
				}
			}
		}

		void DisplayEnemy()
		{
			for(int i = 0, imax = targetList.Count; i < imax; i++)
			{
				Debug.DrawLine(trans.position, targetList[i].position, Color.red);
			}
		}

		[SerializeField] bool bGizmos;
		private void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(transform.position, radius);

			float _angle = angleMax * 0.5f;
			float _angleY = transform.eulerAngles.y;
			Quaternion _rot1 = Quaternion.Euler(Vector3.up * (_angleY - _angle));
			Quaternion _rot2 = Quaternion.Euler(Vector3.up * (_angleY + _angle));

			Vector3 _pos1 = _rot1 * Vector3.forward * radius;
			Vector3 _pos2 = _rot2 * Vector3.forward * radius;

			Gizmos.color = Color.cyan;
			Gizmos.DrawRay(transform.position, _pos1);
			Gizmos.DrawRay(transform.position, _pos2);

			if (bGizmos)
			{
				trans = transform;
				FindEnemy();
				DisplayEnemy();
			}
		}
	}
}