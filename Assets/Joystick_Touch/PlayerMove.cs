using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input = Joystick_Touch.Input;


namespace Joystick_Touch
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
			move.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
			//Debug.Log(move);
			move = move.normalized * speed * Time.deltaTime;
			trans.Translate(move, Space.World);
		}
	}
}