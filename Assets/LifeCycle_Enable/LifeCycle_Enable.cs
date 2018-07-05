using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle_Enable : MonoBehaviour {


	void Awake(){		Debug.Log (this + " Awake");	}
	void OnEnable () {	Debug.Log (this + " OnEnable");	}

	void Start () {		
		Debug.Log (this + " Start -> false");
		enabled = false;
	}

	void FixedUpdate () {Debug.Log (this + " FixedUpdate");	}
	void Update () {	Debug.Log (this + " Update");	}
	void LateUpdate () {Debug.Log (this + " LateUpdate");	}

	void OnDisable () {	Debug.Log (this + " OnDisable");}
	void OnBecameVisible () {	
		Debug.Log (this + " OnBecameVisible -> true");
		enabled = true;
	}
	void OnBecameInvisible () {	Debug.Log (this + " OnBecameInvisible");}
}
