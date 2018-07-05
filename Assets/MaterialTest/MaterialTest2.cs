using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTest2 : MonoBehaviour {
	Renderer renderer;
	Material mat;
	void Start(){
		renderer = GetComponent<Renderer> ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			mat = renderer.material;
			//Debug.Log ("Get <- " + mat);
		} else if (Input.GetKeyDown (KeyCode.Alpha1)) {
			mat = renderer.sharedMaterial;
		}
		
	}
}
