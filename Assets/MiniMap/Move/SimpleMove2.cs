using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleMove2 : MonoBehaviour {
	const string strV = "Vertical";
	const string strH = "Horizontal";
	Vector3 move; 
	public float speed = 2f;

	void Update () {
		move.Set (Input.GetAxisRaw (strH), Input.GetAxisRaw (strV), 0);
		move = move.normalized;
		transform.Translate (move * speed * Time.deltaTime);
	}
}
