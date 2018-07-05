using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SelectAndMove : MonoBehaviour {
	public LayerMask selectMask;
	float maxDistance = 1000f;

	Ray ray;
	RaycastHit hit;
	Camera cam;
	NavMeshAgent target;


	void Start(){
		cam = Camera.main;
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			ray = cam.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, maxDistance, selectMask)) {
				NavMeshAgent _selectTarget = hit.collider.GetComponent<NavMeshAgent> ();
			
				if (_selectTarget != null) {
					target = _selectTarget;
				} else if (target != null) {
					Vector3 _pos = hit.point;
					_pos.y = hit.transform.position.y;
					target.SetDestination (_pos);
				}
			}
		} else if (Input.GetMouseButtonDown (1)) {
			target = null;
		}
	}
}
