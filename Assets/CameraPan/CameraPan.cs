using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraPanTest
{
	public class CameraPan : MonoBehaviour
	{
		public float speedX = 30f;
		public float smoothDampTime = .2f;
		public bool bLimitX;
		public Vector2 LIMIT_X = new Vector2(0f, 0f);
		float currentVelocity;
		Vector3 camLastPos, camNewPos;
		float mouseXLastPos;
		Transform transCamera;

		void Start()
		{
			transCamera = transform;
			camNewPos	= transCamera.position;
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				camLastPos		= transCamera.position;
				camNewPos		= camLastPos;
				mouseXLastPos	= Input.mousePosition.x / Screen.width;
			}

			if (Input.GetMouseButton(0))
			{
				float _x = Input.mousePosition.x / Screen.width - mouseXLastPos;
				camLastPos.x += Mathf.Clamp(-_x, -1f, 1f) * speedX * Time.deltaTime;
				if (bLimitX)
				{
					camLastPos.x = Mathf.Clamp(camLastPos.x, LIMIT_X.x, LIMIT_X.y);
				}
			}

			camNewPos.x = Mathf.SmoothDamp(transCamera.position.x, camLastPos.x, ref currentVelocity, smoothDampTime);
			transCamera.position = camNewPos;
		}
	}
}
