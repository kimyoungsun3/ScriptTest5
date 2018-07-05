using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTest5 : MonoBehaviour {
	Renderer r;
	Material[] matA = new Material[10];


	void Start () {
		r = GetComponent<Renderer> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Debug.Log (this + "matA [0] <- r.material");
			matA [0] = r.material;
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			Debug.Log (this + "matA [1] <- r.sharedMaterial");
			matA [1] = r.sharedMaterial;
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			Debug.Log (this + "matA [0].color <- Color.red");
			matA [0].color = Color.red;
		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			Debug.Log (this + "matA [1].color <- Color.green");
			matA [1].color = Color.green;
		}
		
	}
}
