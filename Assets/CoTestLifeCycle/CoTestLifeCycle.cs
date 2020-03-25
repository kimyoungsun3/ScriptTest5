using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoTestLifeCycle : MonoBehaviour {

	void Awake(){
		Debug.Log(this + " Awake");
		StartCoroutine (CoAwake());
	}

	void Start ()
	{
		Debug.Log(this + " Start");
		StartCoroutine (CoStart());
	}

	void FixedUpdate () {
		Debug.Log (this + " ====FixedUpdate=====");

	}
	void Update () {
		Debug.Log (this + " ====Update=====");

	}
	void LateUpdate () {
		Debug.Log (this + " ====LateUpdate=====");

	}

	IEnumerator CoAwake(){
		while (true) {
			Debug.Log (this + " CoAwake");
			yield return null;
		}
	}

	IEnumerator CoStart(){
		while (true) {
			Debug.Log (this + " CoStart");
			yield return null;
		}
	}
}
