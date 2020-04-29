using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameShoot
{
	public class Door : MonoBehaviour
	{


		[SerializeField] float speed = 10f;
		[SerializeField] Vector3 offset;
		Vector3 underPos, orgPos;
		private void Start()
		{
			orgPos = transform.position;
			underPos = transform.position + offset;
		}

		IEnumerator Co_MoveToward(Vector3 _pos)
		{
			while (transform.position != _pos)
			{
				transform.position = Vector3.MoveTowards(transform.position, _pos, speed * Time.deltaTime);
				yield return null;
			}
		}


		private void OnTriggerEnter(Collider _col)
		{
			if (_col.CompareTag("Player"))
			{
				StopCoroutine("Co_MoveToward");
				StartCoroutine("Co_MoveToward", underPos);
			}
		}

		private void OnTriggerExit(Collider _col)
		{
			if (_col.CompareTag("Player"))
			{
				StopCoroutine("Co_MoveToward");
				StartCoroutine("Co_MoveToward", orgPos);
			}

		}
	}
}
