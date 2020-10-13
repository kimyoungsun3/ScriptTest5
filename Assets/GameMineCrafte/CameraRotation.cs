using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameMineCrafteTest
{
	public class CameraRotation : MonoBehaviour
	{
		public Vector2 ANGLE_MIN_MAX = new Vector2(-60f, +65f);
		Transform trans;
		float angleX, angleY;
		public float sensivityY = 5.0f;
		public float sensivityX = 5.0f;
		public float sensivityW = 10.0f;
		float wheel;
		Transform transCamera;

		// Use this for initialization
		void Start()
		{
			trans	= transform;
			angleY	= trans.eulerAngles.y;
			angleX	= trans.eulerAngles.x;
			transCamera = Camera.main.transform;
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetMouseButton(1))
			{
				angleY += Input.GetAxisRaw("Mouse X") * sensivityX * Time.deltaTime;
				angleX -= Input.GetAxisRaw("Mouse Y") * sensivityY * Time.deltaTime;
				angleX = Mathf.Clamp(angleX, ANGLE_MIN_MAX.x, ANGLE_MIN_MAX.y);
			}			
			wheel = Input.GetAxisRaw("Mouse ScrollWheel") * sensivityW * Time.deltaTime;
		}

		void LateUpdate()
		{
			trans.rotation = Quaternion.Euler(angleX, angleY, 0);
			if (wheel != 0f)
			{
				Vector3 _pos = transCamera.localPosition;
				_pos.z += wheel;
				transCamera.localPosition = _pos;
			}
		}
	}
}