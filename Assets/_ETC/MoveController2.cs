using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController2 : MonoBehaviour {
	public float speedMove = 5f;
	public float speedTurn = 180f;
	Vector2 input;


	void Update () {
		input.Set (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		transform.Translate ( input.y * Vector3.forward * speedMove * Time.deltaTime);
		transform.Rotate ( input.x * Vector3.up * speedTurn * Time.deltaTime);
	}
}
