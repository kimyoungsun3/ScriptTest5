using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLight01{
	public class MoveObject : MonoBehaviour {
		public List<Vector3> points = new List<Vector3> ();
		int idx;
		public float moveSpeed = 5f;

		void Update () {
			if (points [idx] == transform.position) {
				idx++;
				if (idx >= points.Count) {
					idx = 0;
				}
			}

			transform.position = Vector3.MoveTowards (transform.position, points [idx], moveSpeed * Time.deltaTime);
		}
	}
}
