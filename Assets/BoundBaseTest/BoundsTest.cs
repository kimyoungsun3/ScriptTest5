using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoundBaseTest{
	public class BoundsTest : MonoBehaviour {
		SpriteRenderer renderer;

		void Start () {
			renderer = GetComponent<SpriteRenderer> ();
		}

		void OnDrawGizmos(){
			SpriteRenderer _r = GetComponent<SpriteRenderer> ();
			//Debug.Log (_r);
			if(_r != null){
				Util.GizmosDrawBounds(_r.bounds, Color.green);
			}
		}
	}
}
