using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleMove2 : MonoBehaviour {
	Vector3 move; 
	public float speed = 2f;

	void Update () {
		move.Set (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"), 0);
		transform.Translate (move.normalized * speed * Time.deltaTime);
	}
}
