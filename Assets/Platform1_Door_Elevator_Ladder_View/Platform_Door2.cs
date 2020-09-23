using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Door2 : MonoBehaviour {

	Vector3 p0, p1;
	public Vector3 offset;
	public float speed = 2f;

	// Use this for initialization
	void Start () {
		p0 = transform.position;
		p1 = transform.position + offset;
	}

	//Coroutine _c;
	private void OnTriggerEnter(Collider _col)
	{
		//Debug.Log("OnTriggerEnter");
		StopCoroutine("Co_MoveToward");
		StartCoroutine("Co_MoveToward", p1);

		//if (_c != null)
		//{
		//	StopCoroutine(_c);
		//}
		//_c = StartCoroutine(Co_MoveToward(p1));
	}
	private void OnTriggerExit(Collider _col)
	{
		//Debug.Log("OnTriggerExit");
		StopCoroutine("Co_MoveToward");
		StartCoroutine("Co_MoveToward", p0);

		//if (_c != null)
		//{
		//	StopCoroutine(_c);
		//}
		//_c = StartCoroutine(Co_MoveToward(p0));
	}

	IEnumerator Co_MoveToward(Vector3 _targetPos)
	{
		Vector3 _p0 = transform.position;
		Vector3 _p1 = _targetPos;
		//while (transform.position != _p1)
		while (Vector3.Distance(transform.position, _p1) > 0.01f)
		{
			transform.position = Vector3.Lerp( transform.position, _p1, speed * Time.deltaTime);
			yield return null;
		}
	}

	private void OnDrawGizmosSelected()
	{
		Vector3 _p0 = transform.position;
		Vector3 _p1 = transform.position + offset;

		Gizmos.color = Color.red;
		Gizmos.DrawLine(_p0, _p1);
	}
}
