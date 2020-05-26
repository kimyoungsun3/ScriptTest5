using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetResolution : MonoBehaviour {
	public enum eResolutionType { NativeAspect, MyAspect};
	[SerializeField] Vector2 aspectMy = new Vector2(16f, 9f);
	//[SerializeField] Vector2 screen = new Vector2(1280f, 720f);
	[SerializeField] float orthoSize = 5f;
	[SerializeField] eResolutionType type = eResolutionType.NativeAspect;
	[SerializeField] float aspectValue;

	private void OnValidate()
	{
		Camera _camera = Camera.main;
		if (_camera.orthographic)
		{	
			_camera.orthographicSize = orthoSize;
			if(type == eResolutionType.NativeAspect)
			{
				aspectValue = _camera.aspect;
			}
			else
			{
				aspectValue = (aspectMy.x / aspectMy.y);
			}
			Debug.Log(aspectValue + " << " + _camera.aspect + " : " + (aspectMy.x / aspectMy.y));

			//int _w = Screen.width;
			//int _h = Screen.height;
			int _h = Screen.height;
			int _w = (int)(Screen.height * aspectValue);
			Screen.SetResolution(_w, _h, true);
		}
	}
}
