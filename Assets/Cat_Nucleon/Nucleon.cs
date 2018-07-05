using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Nucleon : MonoBehaviour {
	public float attractionForce;
	Rigidbody rigidbody;

	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
	}

	void Update () {
		rigidbody.AddForce (transform.localPosition * -attractionForce);
	}
}
