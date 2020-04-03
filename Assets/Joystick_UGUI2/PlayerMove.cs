using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input = Joystick_UGUI2.Input;

//1. VariableJoystick를 우선 순위에서 올려주세요....
//2. Input를 등록해서 사용하시기를 권함....
namespace Joystick_UGUI2
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
			//move.Set(VariableJoystick.ins.Horizontal, VariableJoystick.ins.Vertical, 0);
			move.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
			move = move.normalized * speed * Time.deltaTime;
			trans.Translate(move, Space.World);
		}
	}
}