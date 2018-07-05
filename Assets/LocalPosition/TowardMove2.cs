using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowardMove2 : MonoBehaviour {
	public Vector3 moveDir = Vector3.up;
	public float speed = 2f;

	void Update () {
		transform.position += moveDir * speed * Time.deltaTime;	
		Debug.Log (this
			+ ":" + transform.position
			+ ":" + Camera.main.WorldToScreenPoint (transform.position)
			+ ":" + Camera.main.WorldToViewportPoint (transform.position)
		);
	}
}
