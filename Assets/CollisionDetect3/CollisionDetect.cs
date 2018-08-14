using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CollisionDetect3{
	public class CollisionDetect : MonoBehaviour {

		void OnCollisionEnter(Collision _col){
			Debug.Log ("OnCollisionEnter:" + this + ":" + _col.gameObject.tag);
		}

		void OnTriggerEnter(Collider _col){
			Debug.Log ("OnTriggerEnter:"  + this + ":" + _col.gameObject.tag);
		}
	}
}