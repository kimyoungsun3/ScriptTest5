using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundCheck : MonoBehaviour {
	Vector3 min, max, move, pos;
	public float moveSpeed = 100f;
	public Vector3 pivot;//pivot is not center
	Vector3 extends;

	void Start () {
		extends = GetComponent<BoxCollider2D>().bounds.extents;
		min = Camera.main.ViewportToWorldPoint (Vector3.zero) + extends;	
		max = Camera.main.ViewportToWorldPoint (Vector3.one) - extends;	

		min += pivot;
		max += pivot;
		Debug.Log (extends + ":" + min + ":" + max);
	}
	
	// Update is called once per frame
	void Update () {
		move.Set (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"), 0);
		transform.Translate (move.normalized * moveSpeed * Time.deltaTime);	

		pos = transform.position;
		if (pos.x < min.x) {
			pos.x = min.x;	
		} else if (pos.x > max.x) {
			pos.x = max.x;
		}

		if (pos.y < min.y) {
			pos.y = min.y;	
		} else if (pos.y > max.y) {
			pos.y = max.y;
		}
		transform.position = pos;
	}

	void OnDrawGizmos(){
		if (Application.isPlaying) {
			Vector3 _min = min;
			Vector3 _max = max;
			_min.z = transform.position.z;
			_max.z = transform.position.z;
			Gizmos.color = Color.green;
			Gizmos.DrawCube (_min, extends);
			Gizmos.DrawCube (_max, extends);
		}
	}
}
