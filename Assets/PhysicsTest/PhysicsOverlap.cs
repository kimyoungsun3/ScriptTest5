using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsOverlap : MonoBehaviour {
	Transform tran;
	public LayerMask mask;
	RaycastHit hit;
	Collider[] cols;
	float distance = 100f;

	void Start(){
		tran = transform;
	}

	void Update () {
		cols = Physics.OverlapSphere (tran.position, distance, mask);	
	}
}
