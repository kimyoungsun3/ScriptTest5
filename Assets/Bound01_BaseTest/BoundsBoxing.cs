using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bound01{
	public class BoundsBoxing : MonoBehaviour {
		public List<BoxCollider2D> colList = new List<BoxCollider2D> ();
		BoxCollider2D col;
		void Start () {
			col = colList [0];
		}


		void Update(){							
			for (int i = 1, _count = colList.Count; i < _count; i++) {
				if (Util.CheckBoundsBoxing (col, colList [i])) {
					Debug.Log (colList [i].name);

					Vector3 _closePoint = col.bounds.ClosestPoint (colList [i].bounds.center);
					//Debug.Log (_closePoint);
					Gizmos2.DebugPoint (_closePoint, Color.green);
				}
			}
		}

	}
}
