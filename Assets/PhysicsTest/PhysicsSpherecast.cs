using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsSpherecast : MonoBehaviour {
	Transform tran;
	public LayerMask mask;
	RaycastHit hit;
	Collider[] cols;
	float distance = 100f;

	void Start(){
		tran = transform;
	}

	void Update () {
		Physics.SphereCast (tran.position, 1f, tran.forward, out hit, distance, mask);
	}
}
