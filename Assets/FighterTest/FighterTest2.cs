using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterTest2 : MonoBehaviour {

	void Start(){
	}

	void OnTriggerEnter(Collider _col){
		Debug.Log (this + "OnTriggerEnter:" + _col.name);
	}

	void OnCollisionEnter(Collision _col){
		Debug.Log (this + "OnCollisionEnter:" + _col.collider.name);
	}
}
