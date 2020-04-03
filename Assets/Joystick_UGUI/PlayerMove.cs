using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Joystick_UGUI
{
	public class PlayerMove : MonoBehaviour
	{
		public float speed = 3f;
		Transform trans;
		Vector3 move;

		void Start()
		{
			trans = transform;
		}

		void Update()
		{
			move.Set(VariableJoystick.ins.Horizontal, VariableJoystick.ins.Vertical, 0);
			move = move.normalized * speed * Time.deltaTime;
			trans.Translate(move, Space.World);
		}
	}
}