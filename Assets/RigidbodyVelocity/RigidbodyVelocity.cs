using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyVelocity : MonoBehaviour {
	public Rigidbody shell;
	public float power = 10;

	void Start(){
		Debug.Log (" 1. Rigidbody.velocity");
		Debug.Log (" 2. Rigidbody.AddForce");
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Rigidbody _rb = Instantiate (shell, transform.position, transform.rotation) as Rigidbody;
			_rb.velocity = _rb.transform.forward * power;
			Destroy (_rb.gameObject, 2f);
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			Rigidbody _rb = Instantiate (shell, transform.position, transform.rotation) as Rigidbody;
			_rb.AddForce(_rb.transform.forward * power);
			Destroy (_rb.gameObject, 2f);
		}
	}
}
