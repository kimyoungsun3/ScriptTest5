using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle_Time : MonoBehaviour {


	void FixedUpdate(){
		Debug.Log ("FU:" + Time.deltaTime);
	}
	void Update () {
		Debug.Log ("U:" + Time.deltaTime);		
	}

	void LateUpdate(){
		Debug.Log ("LU:" + Time.deltaTime);
	}
}
