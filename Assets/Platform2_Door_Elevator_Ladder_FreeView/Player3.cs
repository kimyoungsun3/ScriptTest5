using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platform2_Door_Elevator_Ladder_FreeView
{
	[RequireComponent(typeof(Rigidbody))]
	public class Player3 : MonoBehaviour
	{
		//이동변수....
		public float speed = 2f;
		Transform trans;
		Rigidbody rigidbody;
		float v, h;

		//카메라 좌위회전
		public float speedTurn = 90f;
		float mouseX, mouseY;


		void Start()
		{
			trans		= transform;
			rigidbody	= GetComponent<Rigidbody>();
		}

		// Update is called once per frame
		void Update()
		{
			//1. 입력부분
			v		= Input.GetAxisRaw("Vertical");
			h		= Input.GetAxisRaw("Horizontal");
			mouseX	= Input.GetAxisRaw("Mouse X");
			mouseY	= Input.GetAxisRaw("Mouse Y");
			//if (Input.GetKeyDown(KeyCode.G))
			//{
			//	rigidbody.useGravity = !rigidbody.useGravity;
			//}



		}

		private void FixedUpdate()
		{
			//3. 출력부분, 이동부분......
			if (h !=0 || v != 0)
			{
				trans.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime);
			}

			//좌우 회전...
			//<--- 마우스 (-)
			//     회전(-)
			if(mouseX != 0)
			{
				trans.Rotate(mouseX* Vector3.up * speedTurn * Time.deltaTime);
			}

			if (mouseY != 0)
			{
				trans.Rotate(-mouseY * Vector3.right * speedTurn * Time.deltaTime);
			}

			//2. 연산부분...
			//rigidbody.velocity = Vector3.zero;
			//rigidbody.angularVelocity = Vector3.zero;
		}
	}
}
