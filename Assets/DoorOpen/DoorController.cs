using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoorTest
{
	public class DoorController : MonoBehaviour
	{
		[SerializeField] Vector3 offset;
		[SerializeField] float speed = 2f;
		Vector3 orgPos, destPos;
		Transform trans;
		private void Start()
		{
			trans	= transform;
			orgPos	= trans.position;
			destPos = trans.position + offset;
		}

		IEnumerator Co_MoveToward(Vector3 _pos)
		{
			while (trans.position != _pos)
			{
				trans.position = Vector3.MoveTowards(trans.position, _pos, speed * Time.deltaTime);
				yield return null;
			}
		}

		private void OnTriggerEnter(Collider _other)
		{
			if (_other.CompareTag("Player"))
			{
				StopCoroutine("Co_MoveToward");
				StartCoroutine("Co_MoveToward", destPos);
			}
		}

		private void OnTriggerExit(Collider _other)
		{
			Debug.Log(12);
			if (_other.CompareTag("Player"))
			{
				StopCoroutine("Co_MoveToward");
				StartCoroutine("Co_MoveToward", orgPos);
			}
		}
	}
}