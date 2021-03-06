﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetResolution2 : MonoBehaviour {
	public enum eResolutionType { Aspect16_9, Aspect16_10 };
	[SerializeField] Vector2 screenSize = new Vector2(1280f, 720f);
	[SerializeField] float orthoSize = 5f;
	[SerializeField] eResolutionType type = eResolutionType.Aspect16_9;

	private void Start()
	{
		CheckResolution();
	}

	private void OnValidate()
	{
		CheckResolution();
	}

	private void Update()
	{
		CheckResolution();
	}

	void CheckResolution()
	{

		Camera _camera = Camera.main;
		if (_camera.orthographic)
		{
			_camera.orthographicSize = orthoSize;
			float _aspect = 0;
			if (type == eResolutionType.Aspect16_9)
			{
				_aspect = 16 / 9;
			}
			else if (type == eResolutionType.Aspect16_10)
			{
				_aspect = 16 / 10;
			}

			//int _w = Screen.width;
			//int _h = Screen.height;			
			int _w = (int)(screenSize.x * _aspect);
			int _h = (int)(screenSize.y);
			Debug.Log(_w + ":" + _h);

			switch (kkk)
			{
				case 1:
					Screen.SetResolution(1280, 720, true);
					break;
				case 2:
					Screen.SetResolution(Screen.width, (int) (Screen.width / 2 * 3), true );
					break;
				case 3:
					Screen.SetResolution(Screen.width, Screen.width * 16 / 9, true);
					break;
				case 4:
					Screen.SetResolution((int)(Screen.height * 16 / 9), Screen.height, true);
					break;
			}
		}

	}
	[Range(1,4)][SerializeField]int kkk = 1;
}
