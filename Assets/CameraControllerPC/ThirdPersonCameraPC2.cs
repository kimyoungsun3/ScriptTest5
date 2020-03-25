using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraControllerPC
{
	public class ThirdPersonCameraPC2 : MonoBehaviour
	{
		public Vector2 ANGLE_MIN_MAX = new Vector2(-60f, +65f);
		Transform trans;
		[SerializeField] Transform target;
		float angleX, angleY;
		[SerializeField] float MOUSE_MOVE_Y_SENSITIVITY = 5.0f;
		[SerializeField] float MOUSE_MOVE_X_SENSITIVITY = 5.0f;
		bool bMove;
		float wheel;

		void Start()
		{
			trans	= transform;
			angleY	= trans.eulerAngles.y;
			angleX	= trans.eulerAngles.x;
			bMove	= true;
		}

		void Update()
		{
			//이동은 이곳에 추가하세요...
			if (Input.GetMouseButton(1))
			{
				bMove = true;
				angleY += Input.GetAxis("Mouse X") * MOUSE_MOVE_X_SENSITIVITY * Time.deltaTime;
				angleX -= Input.GetAxis("Mouse Y") * MOUSE_MOVE_Y_SENSITIVITY * Time.deltaTime;
				angleX = Mathf.Clamp(angleX, ANGLE_MIN_MAX.x, ANGLE_MIN_MAX.y);
			}

			//wheel = Input.GetAxis("Mouse ScrollWheel");
			//if (wheel != 0)
			//{
			//	bMove = true;
			//	distance -= Input.GetAxis("Mouse ScrollWheel") * sensivityD;
			//	//Debug.Log (Input.GetAxis ("Mouse ScrollWheel"));

			//	distance = Mathf.Clamp(distance, DISTANCE_MIN, DISTANCE_MAX);
			//}
		}

		void LateUpdate()
		{
			if (bMove)
			{
				Quaternion _q = Quaternion.Euler(angleX, angleY, 0);
				trans.position = target.position + _q * Vector3.back * 10f;

				//trans.rotation = Quaternion.Euler(angleX, angleY, 0);

				bMove = false;
			}
		}
	}

}