using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsLine : MonoBehaviour {
	Transform tran;
	public LayerMask mask;
	RaycastHit hit;
	float distance = 100f;

	void Start(){
		tran = transform;
	}

	void Update () {
		Physics.Linecast (tran.position, tran.forward * distance, out hit, mask);	
	}
}
