using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Joystick_NGUI2
{
	//https://gist.github.com/anonymous/6949309
	public class NGUIJoyStick : MonoBehaviour
	{
		public static NGUIJoyStick ins;

		public Transform tranAnchor;
		public Transform tranTraget;
		public Transform tranBG;
		public float radius = 100f;

		Plane plane;
		Vector3 lastPos, dir;
		bool bDrag = false;
		Ray ray;
		float distance;
		GameObject goTarget, goBG;
		bool bPress, bVisibleSetting;
		[HideInInspector] public Vector3 moveDir;

		void Awake()
		{
			ins = this;
		}

		void Start()
		{
			tranAnchor.gameObject.SetActive(true);
			goTarget = tranTraget.gameObject;
			goBG = tranBG.gameObject;

			VisibleObject(false);
		}

		void VisibleObject(bool _visible)
		{
			bVisibleSetting = false;
			goTarget.SetActive(_visible);
			goBG.SetActive(_visible);
			if (_visible)
			{
				tranAnchor.position = lastPos;
				tranTraget.position = lastPos;
				tranBG.position = lastPos;
			}
			moveDir.Set(0, 0, 0);
		}

		//Press(true) - Relsease(false)
		//UICamera.lastHit.point >> world position
		void OnPress(bool _pressed)
		{
			//Debug.Log("OnPress:" + _pressed);
			if (tranTraget != null)
			{
				if (_pressed)
				{
					lastPos = UICamera.lastHit.point;
					//Debug.Log (lastPos);
					if (plane.normal == Vector3.zero)
					{
						//Debug.Log(">>>");
						//plane = new Plane (UICamera.currentCamera.transform.rotation * Vector3.back, lastPos);
						plane = new Plane(-UICamera.currentCamera.transform.forward, lastPos);
					}
					OnDrag(Vector2.zero);
				}
				//Debug.Log ("OnPress:" + lastPos + ":" + (UICamera.currentCamera.transform.rotation * Vector3.back) + ":" + -UICamera.currentCamera.transform.forward);
				bPress = _pressed;
				bVisibleSetting = true;
			}
		}

		void OnDrag(Vector2 _delta)
		{
			//Debug.Log("OnDrag:" + _delta);
			if (tranTraget != null)
			{
				ray = UICamera.currentCamera.ScreenPointToRay(UICamera.currentTouch.pos);
				//Debug.Log ("OnDrag:"+ UICamera.currentTouch.pos + ":" + ray.origin + ":" + ray.direction);
				if (plane.Raycast(ray, out distance))
				{
					bDrag = true;
					lastPos = ray.GetPoint(distance);
					//Debug.Log (" > OnDrag:" + distance + ":" + lastPos + ":" + UICamera.currentCamera.transform.position);
				}
			}
		}

		void Update()
		{
			//Debug.Log(bVisibleSetting);
			if (bVisibleSetting)
			{
				VisibleObject(bPress);
			}

			if (bDrag)
			{
				tranTraget.position = lastPos;
				//Debug.Log ("update:" + tranTraget.position + ":" + tranTraget.localPosition);
				tranTraget.localPosition = Vector3.ClampMagnitude(tranTraget.localPosition, radius);
				moveDir = tranTraget.localPosition.normalized;
				bDrag = false;
			}
			//Debug.Log ("moveDir:" + moveDir + ":" + tranTraget.localPosition);

			Input.SetAxisMobile(moveDir);
		}

		//void OnDrawGizmos(){
		//	plane
		//}
	}
}