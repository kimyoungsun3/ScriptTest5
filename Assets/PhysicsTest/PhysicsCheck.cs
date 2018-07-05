using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour {
	Transform tran;
	public LayerMask mask;
	RaycastHit hit;
	float distance = 100f;

	void Start(){
		tran = transform;
	}

	void Update () {
		Physics.CheckSphere (tran.position, distance, mask);	
	}
}
