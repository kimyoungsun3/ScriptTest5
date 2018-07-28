using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFixedUpdate : MonoBehaviour {
	public float moveSpeed;
	Vector3 moveDir;
	//float height;

	void Start () {
		//height = transform.position.y;
	}

	void FixedUpdate () {
		float _h = Input.GetAxisRaw ("Horizontal");
		float _v = Input.GetAxisRaw ("Vertical");

		//Debug.Log (_h +":"+ _v);
		Move (_h, _v);


	}

	void Move(float _h, float _v){
		if (_h != 0 || _v != 0) {
			//Debug.Log (" > ");
			moveDir.Set (_h, 0, _v);
			moveDir = moveDir.normalized;
			transform.Translate (moveDir * moveSpeed * Time.deltaTime);
		}
	}
}
