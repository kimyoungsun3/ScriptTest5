using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityEventTest : MonoBehaviour {
	void Awake(){
		Debug.Log ("Awake : " + this);
	}

	void OnEnable(){
		Debug.Log ("OnEnable : " + this);
	}

	void OnDisable(){
		Debug.Log ("OnDisable : " + this);
	}

	void Start () {
		Debug.Log ("Start : " + this);		
	}

	void FixedUpdate(){
		Debug.Log ("FixedUpdate : " + this);	
	}

	void Update () {
		Debug.Log ("Update : " + this);		
	}

	void LateUpdate(){
		Debug.Log ("LateUpdate : " + this);	
	}

	void OnMouseUp(){
		Debug.Log ("OnMouseUp : " + this);	
	}
}
 