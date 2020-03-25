using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Decal_ParticleSystem
{
	public class ThirdPersonCameraNonTargetPC2 : MonoBehaviour
	{
		public Vector2 ANGLE_MIN_MAX = new Vector2(-60f, +65f);
		Transform trans;
		float angleX, angleY;
		public float sensivityY = 5.0f;
		public float sensivityX = 5.0f;
		bool bMove;

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
				angleY += Input.GetAxis("Mouse X") * sensivityX;// * Time.deltaTime;
				angleX -= Input.GetAxis("Mouse Y") * sensivityY;// * Time.deltaTime;
				angleX = Mathf.Clamp(angleX, ANGLE_MIN_MAX.x, ANGLE_MIN_MAX.y);
			}
		}

		void LateUpdate()
		{
			trans.rotation = Quaternion.Euler(angleX, angleY, 0);
		}
	}
}