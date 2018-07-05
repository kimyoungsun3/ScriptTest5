using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleAndDirection : MonoBehaviour {
	
	public float angle;
	Vector3 dir, move;
	void Update () {
		dir.Set (Mathf.Sin (angle * Mathf.Deg2Rad), 0, Mathf.Cos (angle * Mathf.Deg2Rad));
		Debug.DrawRay (transform.position, 3 * dir, Color.green);

		move.Set (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
		move = move.normalized;
		transform.Translate (move * 5 * Time.deltaTime, Space.World);

		float _angle = Mathf.Atan2 (move.x, move.z) * Mathf.Rad2Deg;
		transform.eulerAngles = Vector3.up * _angle;

	}
}
