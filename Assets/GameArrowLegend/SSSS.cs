using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSSS : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public float power = 1000f;
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			GetComponent<Rigidbody>().AddForce(Vector3.forward * power, ForceMode.Force);
		}
	}
}
