using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCM : MonoBehaviour {
	Transform trans;
	public float speedMove = 2f;
	public float speedRotate = 30f;

	// Use this for initialization
	void Start () {
		trans = transform;
	}
	
	// Update is called once per frame
	void Update () {
		float v = Input.GetAxisRaw ("Vertical");
		float h = Input.GetAxisRaw ("Horizontal");

		if (v != 0) {
			trans.Translate (v * Vector3.forward * speedMove * Time.deltaTime);
		}

		if (h != 0) {
			trans.Rotate (h * Vector3.up * speedRotate * Time.deltaTime);
		}

		
	}
}
