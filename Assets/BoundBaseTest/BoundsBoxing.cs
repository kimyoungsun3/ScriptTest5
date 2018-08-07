using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoundBaseTest{
	public class BoundsBoxing : MonoBehaviour {
		public List<BoxCollider2D> list = new List<BoxCollider2D> ();
		BoxCollider2D colMaster;
		void Start () {
			colMaster = list [0];
			
		}


		void Update(){							
			for (int i = 1, _count = list.Count; i < _count; i++) {
				if (Util.CheckBoundsBoxing (colMaster, list [i])) {
					Debug.Log (list [i].name);
				}
			}
		}

	}
}
