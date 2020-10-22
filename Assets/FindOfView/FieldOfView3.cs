using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FindOfView
{
	public class FieldOfView3 : MonoBehaviour {
		Transform trans;
		[SerializeField] float angleMax = 60f;
		[SerializeField] float radius = 3f;
		[SerializeField] LayerMask maskFind, maskBlock;

		// Use this for initialization
		void Start () {
			trans = transform;
			StartCoroutine(Co_FindObject(.5f));
		}
		
		IEnumerator Co_FindObject(float _searchTime)
		{

			Transform _target;
			float _angleMaxHalf = angleMax * .5f;
			float _angle, _distance;
			WaitForSeconds _wait = new WaitForSeconds(_searchTime);
			while (true)
			{
				//1. 충돌체 검사...
				Collider[] _cols = Physics.OverlapSphere(trans.position, radius, maskFind);
				Vector3 _pos = trans.position;
				Vector3 _dir;
				for(int i = 0, _len = _cols.Length; i < _len; i++)
				{
					_target = _cols[i].transform;
					_dir	= _target.position - _pos;

					//2. 시아내인가???...
					_angle = Vector3.Angle(trans.forward, _dir);
					if(_angle <= _angleMaxHalf)
					{
						_distance = _dir.magnitude;
						if(Physics.Raycast(trans.position, _dir, _distance))
						{
							Debug.DrawRay(trans.position, _dir, Color.red);
						}
					}
				}
				yield return _wait;
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(transform.position, radius);

			float _angle = angleMax * 0.5f;
			float _angleY = transform.eulerAngles.y;
			Quaternion _rot1 = Quaternion.Euler(Vector3.up * (_angleY - _angle));
			Quaternion _rot2 = Quaternion.Euler(Vector3.up * (_angleY + _angle));

			Vector3 _pos1 = _rot1 * Vector3.forward* radius;
			Vector3 _pos2 = _rot2 * Vector3.forward * radius;

			Gizmos.color = Color.cyan;
			Gizmos.DrawRay(transform.position, _pos1);
			Gizmos.DrawRay(transform.position, _pos2);
		}
	}
}
