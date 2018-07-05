using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle2Sub : MonoBehaviour {
	public static LifeCycle2Sub ins;
	GameObject go;
	Transform trans;

	void Awake(){
		Debug.Log (this + " >2 Awake");
	}

	void OnEnable(){
		Debug.Log (this + " >2 OnEnable");
	}

	void Start(){
		Debug.Log (this + " >2 Start");
	}
	bool bUpdate;
	void Update(){
		if (!bUpdate) {
			bUpdate = !bUpdate;
			Debug.Log (this + " >2 Update");
		}
	}

	void OnDisable(){
		Debug.Log (this + " >2 OnDisable");
	}
}
