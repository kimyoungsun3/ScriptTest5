using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TouchManager2{
	public class TouchManager : MonoBehaviour {
		public static TouchManager ins { get; private set; }
		NavMeshAgent target;
		Ray ray;
		RaycastHit hit;
		public float distance = 100f;

		void Awake(){
			ins = this;
		}

		void Update () {
			if (Input.GetMouseButtonDown (0)) {
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit, distance)) {
					NavMeshAgent _agent = hit.collider.GetComponent<NavMeshAgent> ();
					if (_agent != null) {
						target = _agent;
						//Debug.Log (11);
					} else if(target != null) {
						target.SetDestination (hit.point);
						//Debug.Log (12);
					}
				}
			}
		}
	}
}