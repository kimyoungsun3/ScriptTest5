using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleMove : MonoBehaviour {
	//delegate void VOID_FUN_VOID();
	//VOID_FUN_VOID callback;
	public enum MoveMode {TransformMode, DirectCallculate};
	public MoveMode mode = MoveMode.TransformMode;
	const string strV = "Vertical";
	const string strH = "Horizontal";
	Vector3 move, dir;
	public float speed = 2f;
	public float speedTurn = 180f;

	int[] arr = new int[]{1, 2, 3, 4};
	int[] arr2 = {1, 2, 3, 4};

	void Start () {
		//Debug.Log (arr [0] + ", " + arr [arr.Length - 1]);
		//Debug.Log (arr2 [0] + ", " + arr2 [arr.Length - 1]);
	}

	void Update () {
		move.Set (Input.GetAxisRaw (strH), 0, Input.GetAxisRaw (strV));
		move = move.normalized;

		if (mode == MoveMode.TransformMode) {
			TransformMove();
		} else if (mode == MoveMode.DirectCallculate) {
			DirectionMove();
		}

	}

	void TransformMove(){
		if (move.z != 0) {
			transform.Translate (move.z * Vector3.forward * speed * Time.deltaTime);
		}

		if (move.x != 0) {
			transform.Rotate (move.x * Vector3.up * speedTurn * Time.deltaTime);
		}
	}

	void DirectionMove(){
		if (move.z != 0) {
			transform.position += move.z * transform.forward * speed * Time.deltaTime;
		}

		if (move.x != 0) {
			transform.eulerAngles += move.x * Vector3.up * speedTurn * Time.deltaTime;
		}
	}
}
