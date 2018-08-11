using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DirectionChange{
	public class FlipChange : MonoBehaviour {
		public Transform prefab;
		public int dir = -1;
		bool[] list = new bool[]{
			true, true, true,
			false, false, false
		};

		// Use this for initialization
		void Start () {
			Transform _t;
			Vector3 _pos;
			Quaternion _q = Quaternion.identity;
			Vector3 _startPos = prefab.position;
			SpriteRenderer _r;
			for (int i = 0, iMax = list.Length; i < iMax; i++) {
				_pos = _startPos + i * Vector3.right * 2 * dir;
				_t = Instantiate (prefab, _pos, _q) as Transform;
				_t.SetParent (transform);

				_r = _t.GetComponent<SpriteRenderer> ();
				if (_r != null){
					_r.flipX = list [i];
				}

				for (int j = 0, jMax = _t.childCount; j < jMax; j++) {
					_r = _t.GetChild(j).GetComponent<SpriteRenderer> ();
					if(_r != null)
						_r.flipX = list [i];
				}
			}

			DestroyImmediate (prefab.gameObject);
			
		}
	}
}
