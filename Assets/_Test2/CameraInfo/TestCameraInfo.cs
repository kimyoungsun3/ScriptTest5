using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraInfo : MonoBehaviour {
	public Transform block, block2;
	public float halfH, halfW;
	public float aspect;
	public float screenWidth, screenHeight, screenAspect;


	void Start () {
		Debug.Log ("카메라의 size를 조절해보삼");

		Vector3 _pos 	= new Vector3 (0, .5f, 0);
		Vector3 _pos2 	= new Vector3 (.5f, 0, 0);
		Vector3 _plus 	= new Vector3 (0, 1, 0);
		Vector3 _plus2 	= new Vector3 (1, 0, 0);
		Transform _t;
		for (int i = 0; i < 10; i++) {
			//Debug.Log (i + ":" + _pos);
			_t = Instantiate (block, _pos, Quaternion.identity) as Transform;
			_t = Instantiate (block2, _pos2, Quaternion.identity) as Transform;

			_pos += _plus;
			_pos2 += _plus2;
			//_t.SetParent (transform);
		}
	}
	
	// Update is called once per frame
	void Update () {
		halfH 	= Camera.main.orthographicSize;
		aspect 	= Camera.main.aspect;
		halfW 	= halfH * aspect;

		screenWidth 	= Screen.width;
		screenHeight 	= Screen.height;
		screenAspect 	= screenWidth / screenHeight;
		
	}
}
