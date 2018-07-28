using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			Vector3 _v = new Vector3 (1, 2, 3);	
			Debug.Log ("ref before:" + _v);
			VectorChange (ref _v);
			Debug.Log ("ref after:" + _v);
		}
	}

	void VectorChange(ref Vector3 _v){
		_v = 3 * _v;
	}

}
