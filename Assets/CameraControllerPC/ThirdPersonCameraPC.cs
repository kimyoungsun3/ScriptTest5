using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraControllerPC
{
	public class ThirdPersonCameraPC : MonoBehaviour
	{
		[SerializeField] Transform targetTrans = null;
		Vector3 oldPos;
		Transform trans;
		Vector3 targetAngle;
		[SerializeField] Vector2 MOUSE_WHEEL_DISTANCE = new Vector2(2f, 20f);
		[SerializeField] float MOUSE_WHEEL_SENSITIVITY = 100f;
		[SerializeField] float MOUSE_MOVE_SENSITIVITY = 10f;
		[SerializeField] [Range(50f, 80f)] float MOUSE_ROTATEX_LIMIT = 60f;
		[SerializeField] float MOUSE_ROTATE_SENSITIVITY = 10f;
		Vector3 targetOrgPos;

		void Start()
		{
			trans = transform;

			trans.SetParent(targetTrans);
			trans.LookAt(targetTrans);

			targetOrgPos	= targetTrans.localPosition;
			targetAngle		= targetTrans.localEulerAngles;
		}

		void LateUpdate()
		{
			float _delta = Input.GetAxis("Mouse ScrollWheel");
			if (_delta != 0.0f)
			{
				MouseWheelEvent(_delta);
			}

			if (Input.GetMouseButtonDown(2) || Input.GetMouseButtonDown(1))
			{
				oldPos = Input.mousePosition;
			}

			if (Input.GetKeyDown(KeyCode.R))
			{
				targetTrans.localPosition = targetOrgPos;
			}

			MouseDragEvent(Input.mousePosition);
		}

		void MouseDragEvent(Vector3 _mousePos)
		{
			Vector3 _dirMouse = _mousePos - oldPos;

			if (Input.GetMouseButton(2))
			{
				if (_dirMouse.magnitude > Vector3.kEpsilon)
					CameraTranslate(-_dirMouse / 100.0f);
			}
			else if (Input.GetMouseButton(1))
			{
				CameraRotate(new Vector3(-_dirMouse.y, _dirMouse.x, 0));
			}
			oldPos = _mousePos;
		}

		public void MouseWheelEvent(float _delta)
		{
			Vector3 _dir		= targetTrans.position - trans.position;
			Vector3 _deltaPos	= _dir.normalized * _delta * Time.deltaTime * MOUSE_WHEEL_SENSITIVITY;
			Vector3 _newPos		= trans.position + _deltaPos;

			//direction bug가 존재하는 구간임....
			float _newDistance = (targetTrans.position - _newPos).magnitude;
			if (_newDistance <= MOUSE_WHEEL_DISTANCE.x)
			{
				_newPos -= _deltaPos;
			}
			else if (_newDistance >= MOUSE_WHEEL_DISTANCE.y)
			{
				_newPos -= _deltaPos;
			}
			trans.position = _newPos;
		}

		void CameraTranslate(Vector3 _dir)
		{
			targetTrans.Translate(Vector3.right * _dir.x * Time.deltaTime * MOUSE_MOVE_SENSITIVITY);
			targetTrans.Translate(Vector3.up * _dir.y * Time.deltaTime * MOUSE_MOVE_SENSITIVITY);
		}

		public void CameraRotate(Vector3 _dir)
		{
			targetAngle += _dir * Time.deltaTime * MOUSE_ROTATE_SENSITIVITY;
			targetAngle.x = Mathf.Clamp(targetAngle.x, -MOUSE_ROTATEX_LIMIT, +MOUSE_ROTATEX_LIMIT);
			targetTrans.localEulerAngles = targetAngle;
		}
	}
}