using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoundSelect{
	public class CreateObject : MonoBehaviour {
		public int count = 10;
		public float radius = 20f;
		public Transform prefab;
		[HideInInspector] public List<BoxCollider2D> list = new List<BoxCollider2D> ();

		void Start () {
			Vector3 _pos;
			Transform _t;
			for (int i = 0; i < count; i++) {
				_pos = new Vector3 (Random.Range (-radius, radius), Random.Range (-radius, radius), transform.position.z);
				_t = Instantiate (prefab, _pos, Quaternion.identity) as Transform;
				_t.name += (i + 1);
				list.Add (_t.GetComponent<BoxCollider2D>());
			}

			Debug.Log (" Rect Area Select");
		}

	}
}
