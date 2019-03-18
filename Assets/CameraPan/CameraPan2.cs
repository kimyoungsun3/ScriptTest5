using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraPanTest
{
	public class CameraPan2 : MonoBehaviour
	{
		public float speedX = 30f;
		public float smoothDampTime = .2f;
		public bool bLimitX;
		Vector3 camLastPos, camNewPos;

		Transform transCamera;
		Vector3 dragOriginal;
		public Vector2 LIMIT_X = new Vector2(-10f, 10f);
		float distance, dummyCurrentVelocity;

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
				dragOriginal	= Input.mousePosition;
			}

			if (Input.GetMouseButton(0))
			{
				float _x = -(Input.mousePosition - dragOriginal).x;
				float _distanceNew = Mathf.Abs(_x);
				if(_distanceNew < distance)
				{
					dragOriginal	= Input.mousePosition;
					_x				= 0;
					_distanceNew	= 0;
				}
				distance = _distanceNew;


				_x = _x / Screen.width;
				camLastPos.x += Mathf.Clamp(_x, -1f, 1f) * speedX * Time.deltaTime;
				if (bLimitX)
				{
					camLastPos.x = Mathf.Clamp(camLastPos.x, LIMIT_X.x, LIMIT_X.y);
				}
			}

			camNewPos.x = Mathf.SmoothDamp(transCamera.position.x, camLastPos.x, ref dummyCurrentVelocity, smoothDampTime);
			transCamera.position = camNewPos;
		}
	}
}
