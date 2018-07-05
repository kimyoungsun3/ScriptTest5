using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TouchManager : MonoBehaviour {
	public static TouchManager ins;
	NavMeshAgent target;
	Ray ray;
	RaycastHit hit;

	void Awake(){
		ins = this;
	}

	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 100)) {
				NavMeshAgent _target = hit.collider.GetComponent<NavMeshAgent> ();
				if (_target != null) {
					target = _target;
				} else if(target != null) {
					target.SetDestination (hit.point);
				}
			}
		}
	}

}
