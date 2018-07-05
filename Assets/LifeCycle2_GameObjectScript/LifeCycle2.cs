using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle2 : MonoBehaviour {
	public static LifeCycle2 ins;
	GameObject go;
	Transform trans;

	void Awake(){
		Debug.Log (this + " >1 Awake");
		ins 	= this;
		go 		= gameObject;
		trans 	= transform;

		go.SetActive (false);
	}

	void OnEnable(){
		Debug.Log (this + " >1 OnEnable");
	}

	void Start(){
		Debug.Log (this + " >1 Start");
	}

	void SetActive2(bool _b){
		Debug.Log (this + " >1 SetActive2");
		if (go == null) {
			Debug.Log (" null >1 SetActive2");
			gameObject.SetActive (true);
			go = gameObject;
		}

		go.SetActive (_b);
	}

	bool bUpdate;
	void Update(){
		if (!bUpdate) {
			bUpdate = !bUpdate;
			Debug.Log (this + " >1 Update");
		}
	}

	public void InvokeVisible(){
		SetActive2 (true);
	}
	public void InvokeInVisible(){
		SetActive2 (false);
	}

	void OnDisable(){
		Debug.Log (this + " >1 OnDisable");
	}
}
