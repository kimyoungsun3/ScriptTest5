using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsExplose : MonoBehaviour {
	public float distance = 5f;
	public LayerMask mask;
	public float explosionForce = 100f;
	public float explosionRadius = 3f;
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {	
			Collider[] c = Physics.OverlapSphere (transform.position, distance, mask);
			int _len = c.Length;
			Rigidbody rb;
			if(_len > 0){
				for (int i = 0; i < _len; i++) {
					rb = c [i].GetComponent<Rigidbody> ();
					if (rb != null) {
						rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
					}
				}		
			}
		}
	}
}
