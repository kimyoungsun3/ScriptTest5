using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchToZoom : MonoBehaviour {
	public float perspectiveZoomSpeed = 0.5f;
	public float orthoZoomSpeed = .5f;
	public Camera camera;
	private void Start()
	{
		if (camera == null)
			camera = Camera.main;
	}

	void Update()
	{
		if (Application.platform == RuntimePlatform.WindowsEditor)
		{
			if (camera.orthographic)
			{
				if (Input.GetAxis("Mouse ScrollWheel") < 0)
					camera.orthographicSize += orthoZoomSpeed;
				else if (Input.GetAxis("Mouse ScrollWheel") > 0)
					camera.orthographicSize -= orthoZoomSpeed;
				camera.orthographicSize = Mathf.Clamp(camera.orthographicSize, 1f, 20f);
			}
			else
			{
				if (Input.GetAxis("Mouse ScrollWheel") < 0)
					camera.fieldOfView++;
				else if (Input.GetAxis("Mouse ScrollWheel") > 0)
					camera.fieldOfView--;
				camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 10f, 70f);
			}
		}
		else
		{
			if(Input.touchCount == 2)
			{
				Touch touchZero = Input.GetTouch(0);
				Touch touchOne = Input.GetTouch(1);

				Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
				Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

				float preTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
				float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

				float deltaMagnitudeDiff = preTouchDeltaMag - touchDeltaMag;

				if (camera.orthographic)
				{
					camera.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;
					camera.orthographicSize = Mathf.Max(camera.orthographicSize, 0.1f);
				}
				else
				{
					camera.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;
					camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 10f, 70f);
				}
			}
		}
	}
}
