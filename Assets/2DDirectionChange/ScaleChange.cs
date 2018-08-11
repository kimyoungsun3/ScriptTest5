using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DirectionChange{
	public class ScaleChange : MonoBehaviour {
		public Transform prefab;
		public int dir = -1;
		Vector3[] list = new Vector3[]{
			new Vector3(-1.0f, 1, 1), new Vector3(-.5f, 1, 1), new Vector3(-.1f, 1, 1),
			new Vector3(.1f, 1, 1), new Vector3(.5f, 1, 1), new Vector3(1f, 1, 1)

		};

		void Start () {
			Transform _t;
			Vector3 _pos;
			Quaternion _q = Quaternion.identity;
			Vector3 _startPos = prefab.position;
			for (int i = 0, iMax = list.Length; i < iMax; i++) {
				_pos = _startPos + i * Vector3.right * 2 * dir;
				_t = Instantiate (prefab, _pos, _q) as Transform;
				_t.SetParent (transform);
				_t.localScale = list [i];
				_t.name = list [i].x.ToString ();
			}

			DestroyImmediate (prefab.gameObject);
		}

	}
}
