using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfVeiw2 : MonoBehaviour {

	public float angleMax = 60f;
	public float radius = 10;

	void Start(){
	}


	void OnDrawGizmos(){
		Debug.DrawLine (transform.position, AngleToDir (-angleMax / 2f)* radius, Color.gray);
		Debug.DrawLine (transform.position, AngleToDir (+angleMax / 2f)* radius, Color.blue);

		Debug.DrawLine (transform.position, QuaternionToPosition(AngleToQuaternion (-angleMax / 2f - 5), radius), Color.red);
		Debug.DrawLine (transform.position, QuaternionToPosition(AngleToQuaternion (+angleMax / 2f + 5), radius), Color.green);

	}

	Vector3 AngleToDir(float _angle, bool _bLocal = false){
		if (!_bLocal) {
			_angle += transform.eulerAngles.y;
		}

		return new Vector3 (
			Mathf.Sin (_angle * Mathf.Deg2Rad),
			0,
			Mathf.Cos (_angle * Mathf.Deg2Rad)
		);
	}

	Quaternion AngleToQuaternion(float _angle, bool _bLocal = false){
		if (!_bLocal) {
			_angle += transform.eulerAngles.y;
		}

		return Quaternion.Euler (Vector3.up * _angle);
	}

	Vector3 QuaternionToPosition(Quaternion _q, float _radius){
		return transform.position + _q * Vector3.forward * _radius;
	}


}
