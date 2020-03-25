using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy_ACTest
{

	public class Enemy_ACTest : MonoBehaviour
	{
		Animator animator;

		private void Start()
		{
			animator = GetComponent<Animator>();
		}
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				animator.SetInteger("state", 0);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				animator.SetInteger("state", 1);
			}
			else if (Input.GetKeyDown(KeyCode.Space))
			{
				animator.SetTrigger("attack");
			}
		}
	}
}
