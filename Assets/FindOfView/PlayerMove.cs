using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FindOfView
{
	public class PlayerMove : MonoBehaviour
	{
		[SerializeField] float speedMove = 3f;
		[SerializeField] float speedTurn = 180f;
		Transform trans;
		Vector3 move, rotate;
		Animator animator;

		void Start()
		{
			trans = transform;
			animator = GetComponentInChildren<Animator>();
		}

		void Update()
		{
			move.Set(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
			move = move.normalized * speedMove * Time.deltaTime;
			trans.Translate(move, Space.World);

			if(move.sqrMagnitude != 0)
			{
				animator.SetInteger("state", 1);
			}
			else
			{
				animator.SetInteger("state", 0);
			}

			if (Input.GetMouseButtonDown(0))
			{
				animator.SetTrigger("attack");
			}
		}
	}
}
