using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInfo : MonoBehaviour {
	public float camHeight, camWidth;
	void Update () {
		camHeight = Camera.main.orthographicSize * 2f;	
		camWidth = Camera.main.orthographicSize * Camera.main.aspect * 2f;	

		Debug.Log ("camWidth:" + camWidth + " camHeight:" + camHeight);
	}

}
