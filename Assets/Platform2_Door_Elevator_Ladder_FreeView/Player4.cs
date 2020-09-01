using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platform2_Door_Elevator_Ladder_FreeView
{
	[RequireComponent(typeof(Rigidbody))]
	public class Player4 : MonoBehaviour
	{
		//이동변수....
		public float speed = 2f;
		Transform trans;
		Rigidbody rigidbody;
		float v, h;

		//카메라 좌위회전
		public float speedTurn = 90f;
		float mouseX, mouseY;
		float angleX, angleY;
		public Vector2 angleXMinMax = new Vector2(-30f, +60f);

		public static Player4 ins;
		private void Awake()
		{
			if(ins != null)
			{
				Destroy(gameObject);
				return;
			}
			ins = this;
			DontDestroyOnLoad(gameObject);
		}


		void Start()
		{
			trans		= transform;
			rigidbody	= GetComponent<Rigidbody>();

			//1 처음 각도를 저장해둔다...
			Vector3 _angle = trans.eulerAngles;
			angleX = _angle.x;
			angleY = _angle.y;
		}

		// Update is called once per frame
		void Update()
		{
			//1. 입력부분
			v		= Input.GetAxisRaw("Vertical");
			h		= Input.GetAxisRaw("Horizontal");
			mouseX	= Input.GetAxisRaw("Mouse X");
			mouseY	= Input.GetAxisRaw("Mouse Y");

			//2-1. 좌우 회전
			angleY  += mouseX * speedTurn * Time.deltaTime;
			angleX	-= mouseY * speedTurn * Time.deltaTime;
			angleX = Mathf.Clamp(angleX, angleXMinMax.x, angleXMinMax.y);

		}

		private void FixedUpdate()
		{
			//3. 출력부분, 이동부분......
			if (h !=0 || v != 0)
			{
				trans.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime);
			}

			if(angleY != 0 || angleX != 0)
			{
				trans.rotation = Quaternion.Euler(angleX, angleY, 0);
			}
			
			//2. 연산부분...
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
		}
	}
}
