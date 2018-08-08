using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bound01{
	public class BoundsTest : MonoBehaviour {
		SpriteRenderer renderer;
		public bool bChange;

		void Start () {
			renderer = GetComponent<SpriteRenderer> ();
		}

		void OnDrawGizmos(){
			SpriteRenderer _r = GetComponent<SpriteRenderer> ();
			//Debug.Log (_r);
			if(_r != null){
				if(bChange)
					Util.GizmosDrawBounds(_r.bounds, Color.green);
				else
					Gizmos2.DebugBounds (_r.bounds, Color.red);
			}
		}
	}
}
