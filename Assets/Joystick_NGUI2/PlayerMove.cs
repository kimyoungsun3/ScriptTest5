using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input = Joystick_NGUI2.Input;


namespace Joystick_NGUI2
{
	public class PlayerMove : MonoBehaviour
	{
		public float speed = 3f;
		Transform trans;
		Vector3 move;

		void Start()
		{
			trans		= transform;
		}

		void Update()
		{
			move.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
			move = move.normalized * speed * Time.deltaTime;
			trans.Translate(move, Space.World);
		}
	}
}