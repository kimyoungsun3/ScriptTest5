using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGUI_001_UICameraInfo
{
	public class UiCameraInfo : MonoBehaviour
	{
		public UICamera current;
		public string currentName;
		public Camera currentCamera;
		public int currentTouchID;
		// Use this for initialization
		void Start()
		{
			Debug.Log("1. 마우스를 이리 저리 움직이시면 정보가 보임");
			Debug.Log("2. M:마우스 T:터치 ON/OFF");
			SetAndDisplay("Start");
		}

		void SetAndDisplay(string _from)
		{

			Debug.Log(_from);
			current			= UICamera.current;
			currentName		= current ? current.name:"";
			currentCamera	= UICamera.currentCamera;
			currentTouchID	= UICamera.currentTouchID;
		}

		void OnHover(bool _hover)
		{
			SetAndDisplay("OnHover:" + _hover);
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.M))
			{
				current.useMouse = !current.useMouse;
			}

			if (Input.GetKeyDown(KeyCode.T))
			{
				current.useTouch = !current.useTouch;
			}

		}

	}

}