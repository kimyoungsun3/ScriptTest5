using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LookAt{
	public class ObjectLookAt2D : MonoBehaviour {
		Transform transTarget;
		Vector3 pos, pos2;
		float originalZ;
		public float speedLookAt = 30f;
		List<GameObject> list;
		int index = -1;

		void Start(){
			originalZ = transform.position.z;
			list = new List<GameObject>(GameObject.FindGameObjectsWithTag ("Player"));
		}

		void Update () {
			if (Input.GetKeyDown (KeyCode.Space)) {
				index = (index + 1) % list.Count;
				transTarget = list [index].transform;
			}

			//----------------------------------------
			if (transTarget != null) {
				pos 	= transform.position;
				pos2 	= transTarget.position;
				pos 	= Vector3.Lerp (pos, pos2, speedLookAt * Time.deltaTime);
				pos.z 	= originalZ;
				transform.position = pos;
			}
		}
	}
}
