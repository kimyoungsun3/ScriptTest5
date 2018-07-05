using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsRay : MonoBehaviour {
	Transform tran;
	public LayerMask mask;
	RaycastHit hit;
	Collider[] cols;
	float distance = 100f;

	void Start(){
		tran = transform;


		//Vector3 _pos = tran.position;
		//_pos.x = 1;
		//tran.position = _pos;

		//tran.position.x = 1f;
	}

	void Update () {
		Physics.Raycast (tran.position, tran.forward, out hit, distance, mask);	
	}
}
