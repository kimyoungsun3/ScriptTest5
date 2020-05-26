using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetResolution2 : MonoBehaviour {
	public enum eResolutionType { Aspect16_9, Aspect16_10};
	[SerializeField] Vector2 screenSize = new Vector2(1280f, 720f);
	[SerializeField] float orthoSize = 5f;
	[SerializeField] eResolutionType type = eResolutionType.Aspect16_9;

	private void OnValidate()
	{
		Camera _camera = Camera.main;
		if (_camera.orthographic)
		{	
			_camera.orthographicSize = orthoSize;
			float _aspect = 0;
			if(type == eResolutionType.Aspect16_9)
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
			int _h = (int)(screenSize.y * .5f);
			Screen.SetResolution(_w, _h, true);
		}
	}
}
