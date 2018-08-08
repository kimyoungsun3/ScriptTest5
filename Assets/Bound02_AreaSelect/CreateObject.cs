using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bound02{
	public class CreateObject : MonoBehaviour {
		public int count = 10;
		public float radius = 20f;
		public Transform prefab;
		[HideInInspector] public List<BoxCollider2D> listCols = new List<BoxCollider2D> ();

		void Start () {
			Vector3 _pos;
			Transform _t;
			for (int i = 0; i < count; i++) {
				_pos = new Vector3 (Random.Range (-radius, radius), Random.Range (-radius, radius), transform.position.z);
				_t = Instantiate (prefab, _pos, Quaternion.identity) as Transform;
				_t.name += (i + 1);
				listCols.Add (_t.GetComponent<BoxCollider2D>());
			}

			Debug.Log (" Rect Area Select");
		}

		public void CheckHitObject(Bounds _hitArea){
			Collider2D _col;
			BoundsSelect _scp;
			for (int i = 0, iMax = listCols.Count; i < iMax; i++) {
				_col = listCols [i];
				if (_hitArea.Intersects (_col.bounds)) {
					_scp = _col.GetComponent<BoundsSelect> ();
					if (_scp == null) {
						//empty => Add 
						_scp = _col.gameObject.AddComponent<BoundsSelect>();
					}
					_scp.SetSelect (true);
				} else {
					_scp = _col.GetComponent<BoundsSelect> ();
					if (_scp != null) {
						_scp.SetSelect (false);
					}
				}
			}
		}

	}
}
