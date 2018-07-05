using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTTTT : MonoBehaviour {
	private Light light;

	// Use this for initialization
	void Start () {
		light = GetComponent<Light> ();	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && light != null) {
			light.enabled = !light.enabled;
		}
	}
}
