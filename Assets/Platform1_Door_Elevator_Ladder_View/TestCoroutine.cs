using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platform_Door_Elevator
{
	public class TestCoroutine : MonoBehaviour
	{
		public Transform p0, p1;
		public float speed = 2f;
		// Use this for initialization
		void Start()
		{
			//Debug.Log("Start");
			//StartCoroutine("Co_MoveToward", target.position);
		}

		//Update is called once per frame
		void Update()
		{
			//Debug.Log("Update");
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				StopCoroutine("Co_MoveToward");
				StartCoroutine("Co_MoveToward", p1.position);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				StopCoroutine("Co_MoveToward");
				StartCoroutine("Co_MoveToward", p0.position);
			}
		}

		IEnumerator Co_MoveToward(Vector3 _targetPos)
		{
			Vector3 _p0 = transform.position;
			Vector3 _p1 = _targetPos;
			//while (transform.position != _p1)
			while (Vector3.Distance(transform.position, _p1) > 0.01f)
			{
				Debug.Log("Co_MoveToward");
				transform.position = Vector3.Lerp(
					transform.position,
					_p1,
					speed * Time.deltaTime);
				yield return null;
			}
		}

		//IEnumerator Co_MoveToward(int _loop)
		//{
		//	while (_loop > 0)
		//	{
		//		Debug.Log("Co_MoveToward " + _loop);
		//		_loop--;
		//		yield return null;
		//	}
		//}
	}

}