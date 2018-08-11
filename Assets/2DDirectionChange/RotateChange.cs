using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DirectionChange{
	public class RotateChange : MonoBehaviour {
		public Transform prefab;
		public int dir = -1;
		float[] list = new float[]{
			180, 115, 96,
			84,   65,  0
		};

		void Start () {
			Transform _t;
			Vector3 _pos;
			Quaternion _q;
			Vector3 _startPos = prefab.position;
			for (int i = 0, iMax = list.Length; i < iMax; i++) {
				_pos = _startPos + i * Vector3.right * 2 * dir;
				_q = Quaternion.Euler (0, list [i], 0);
				_t = Instantiate (prefab, _pos, _q) as Transform;
				_t.SetParent (transform);
				//_t.localScale = list [i];
				_t.name = list [i].ToString ();
			}

			DestroyImmediate (prefab.gameObject);
		}

	}
}
