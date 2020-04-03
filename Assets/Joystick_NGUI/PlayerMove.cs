using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Joystick_NGUI
{
	public class PlayerMove : MonoBehaviour
	{
		public float speed = 3f;
		Transform trans;
		Vector3 move;
		NGUIJoyStick joystick;

		void Start()
		{
			trans		= transform;
			joystick	= NGUIJoyStick.ins;
		}

		void Update()
		{
			move.Set(joystick.moveDir.x, joystick.moveDir.y, 0);
			move = move.normalized * speed * Time.deltaTime;
			trans.Translate(move, Space.World);
		}
	}
}