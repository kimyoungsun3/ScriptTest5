using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCycle : MonoBehaviour {

	void Awake(){
		Debug.Log ("Awake()" + this);
	}

	void OnEnable(){
		Debug.Log ("OnEnable()" + this);
	}

	void Start () {
		Debug.Log ("Start()" + this);		
	}

	void FixedUpdate(){
		Debug.Log ("FixedUpdate()" + this);
	}

	void Update () {
		Debug.Log ("Update()" + this);	
	}

	void LateUpdate(){
		Debug.Log ("LateUpdate()" + this);
	}
}
