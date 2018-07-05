using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {
	
	void Start () {
		
	}
	
	void Update () {
		Debug.Log (transform.forward + " , " + transform.TransformDirection (Vector3.forward));	
	}
}
