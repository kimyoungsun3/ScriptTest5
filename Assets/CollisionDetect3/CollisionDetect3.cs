using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect3 : MonoBehaviour {

	void OnCollisionEnter(Collision _col){
		Debug.Log ("C:" + _col.gameObject.tag);
	}

	void OnTriggerEnter(Collider _col){
		Debug.Log ("T:" + _col.gameObject.tag);

	}
}
