using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalizeMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float v = Input.GetAxisRaw ("Vertical");
		float h = Input.GetAxisRaw ("Horizontal");
		Vector3 move = new Vector3 (h, v, 0);
		transform.Translate (5*move * Time.deltaTime);	
	}
}
