using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C3 : MonoBehaviour {
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			StopAllCoroutines ();
			StartCoroutine (Co_Rotate());
		}		
	}

	//public AnimationCurve curve;
	public float turnAngle = 90f;
	public float turnTime = .5f;
	public Transform transCam;
	IEnumerator Co_Rotate(){

		float _time = 0;
		float _turnSpeed = turnAngle / turnTime;
		Vector3 _up = Vector3.up;
		float _angle = transform.eulerAngles.y + turnAngle;
		while (_time < turnTime) {
			_time += Time.deltaTime;
			transform.eulerAngles += _up * _turnSpeed * Time.deltaTime;
			yield return null;
		}
		transform.eulerAngles = _up * _angle;
	}
}
