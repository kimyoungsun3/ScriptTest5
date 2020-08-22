using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform2_Door_Elevator_Ladder_FreeView
{
	public class CameraController : MonoBehaviour
	{
		public Vector2 ANGLE_MIN_MAX	= new Vector2(5f, +65f);
		public Vector3 DISTANCE_MIN_MAX = new Vector2(3f, 15f);
		public Transform target;
		public float climpDampSpeed = 5f;
			 
		//Vector3 targetPosOld;

		Transform trans;
		float distance = 10f;
		float distanceBack = -1f;
		float angleX;
		public float sensivityY = 5.0f;	//센서 mouseY
		public float sensivityW = 15.0f;//센서 wheel
		Quaternion dirQ;
		float wheel;

		void Start()
		{
			trans = transform;
			trans.LookAt(target);

			//angleY = trans.eulerAngles.y;
			angleX = trans.eulerAngles.x;
		}


		void Update()
		{
			//상하회전...
			angleX	-= Input.GetAxis("Mouse Y") * sensivityY;
			angleX	= Mathf.Clamp(angleX, ANGLE_MIN_MAX.x, ANGLE_MIN_MAX.y);

			//wheel. 앞(+), 뒤(-)
			wheel = Input.GetAxis("Mouse ScrollWheel");
			if (wheel != 0f)
			{
				distance -= wheel * sensivityW;// * Time.deltaTime;
				distance = Mathf.Clamp(distance, DISTANCE_MIN_MAX.x, DISTANCE_MIN_MAX.y);
			}

			/*
			 * 캐릭터 - 장애물(콜라이더)- 카메라
			 * 캐릭터 - 카메라 - 장애물  <- (앞으로땡김)
			 * 
			/**/
			Vector3 _targetPoint	= target.position;
			Vector3 _dirBack		= trans.position - _targetPoint;
			RaycastHit _hitBack;
			if (Physics.Raycast(_targetPoint, _dirBack, out _hitBack, distance))
			{
				//if(_hitBack.collider.gameObject != target.gameObject)
				{
					if (distanceBack == -1f)
					{
						distanceBack = distance;
					}
					distance = _hitBack.distance;
				}
			}
			else
			{
				if (distanceBack != -1f && !Physics.Raycast(_targetPoint, _dirBack, out _hitBack, distanceBack))
				{
					distance = distanceBack;
					distanceBack = -1f;
				}
			}
		}

		void LateUpdate()
		{
			//Y값은 오리지널 현재의 값을 사용한다.
			dirQ = Quaternion.Euler(angleX, trans.eulerAngles.y, 0);

			Vector3 _pos	= target.position - dirQ * Vector3.forward * distance;
			trans.position	= Vector3.Slerp (trans.position, _pos, Time.deltaTime * climpDampSpeed);
			//trans.position = target.position - dirQ * Vector3.forward * distance;
			trans.rotation = dirQ;
			//trans.LookAt (target.position);
			//}
			//targetPosOld = target.position; 		
		}
	}
}