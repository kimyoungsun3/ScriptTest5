using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CollisionDetect3{
	public class CollisionDetect : MonoBehaviour {

		void OnCollisionEnter(Collision _col)
		{
			Debug.Log (this + " <OnCollisionEnter> " + _col.gameObject.name);
		}

		void OnTriggerEnter(Collider _col)
		{
			Debug.Log(this + " <OnTriggerEnter> " + _col.gameObject.name);
		}
	}
}