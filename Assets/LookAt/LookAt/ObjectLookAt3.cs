using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LookAt{
	public class ObjectLookAt3 : MonoBehaviour {
		public List<Transform> listTargets = new List<Transform>();
		int index = 0;
		Transform transTarget;

		// Use this for initialization
		void Start () {
			if (listTargets.Count > 0) {
				transTarget = listTargets [index];
			}
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetKeyDown (KeyCode.Space)) {
				index = (index + 1) % listTargets.Count;
				transTarget = listTargets [index];
			}

			if (transTarget != null) {
				transform.LookAt (transTarget);
			}
		}
	}
}