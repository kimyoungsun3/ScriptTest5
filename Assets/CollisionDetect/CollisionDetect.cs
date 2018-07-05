using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour {
	public float speed = 3f;
	Rigidbody rigidbody;
	Vector3 move;

	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
	}

	void Update () {
		move.Set (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
		move = move.normalized * speed * Time.deltaTime;
		//rigidbody.MovePosition(rigidbody.position + move);
		transform.Translate(move, Space.World);
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
	}

	void OnTriggerEnter(Collider _col){
		Debug.Log ("OnTriggerEnter " + _col.gameObject.name);
	}

	void OnCollisionEnter(Collision _col){
		Debug.Log ("OnCollisionEnter " + _col.collider.gameObject.name);
	}
}
