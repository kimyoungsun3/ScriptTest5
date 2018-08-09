using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bound02{
	public class BoundsSelect : MonoBehaviour {
		SpriteRenderer renderer;
		public bool bSelected;

		void Start () {
			renderer = GetComponent<SpriteRenderer> ();
		}

		public void SetSelect(bool _b){
			bSelected = _b;
		}

		void OnDrawGizmos(){
			SpriteRenderer _r = GetComponent<SpriteRenderer> ();
			if(_r != null){
				if (bSelected) {
					_r.color = Color.red;
					Util.GizmosDrawBounds (_r.bounds, Color.green);
				} else {
					_r.color = Color.white;
					Gizmos2.DebugBounds (_r.bounds, Color.grey);
				}
			}
		}
	}
}
