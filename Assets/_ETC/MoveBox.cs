using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox: MonoBehaviour {
	public enum MoveState{
		MoveXY, 
		MoveXZ,
		MoveX,
		Rotate
	};
	public MoveState moveState = MoveState.MoveXY;
	public float speed = 3f;
	public float speedRotate = 30f;
	Transform trans;
	GameObject gameo;
	Vector3 move, rotate;

	void Start () {
		trans = transform;
		gameo = gameObject;		
	}	

	void Update () {
		if (moveState == MoveState.MoveXZ) {
			move.Set (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
			move = move.normalized * speed * Time.deltaTime;
			trans.Translate(move, Space.World);
		}else if (moveState == MoveState.MoveXY) {
			move.Set (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"), 0);
			move = move.normalized * speed * Time.deltaTime;
			trans.Translate(move, Space.World);
		}else if (moveState == MoveState.MoveX) {
			move.Set (Input.GetAxisRaw ("Horizontal"), 0, 0);
			move = move.normalized * speed * Time.deltaTime;
			trans.Translate(move, Space.World);
		}else if (moveState == MoveState.Rotate) {
			rotate.Set(
				Input.GetAxisRaw ("Vertical") * speedRotate * Time.deltaTime,
				Input.GetAxisRaw ("Horizontal") * speedRotate * Time.deltaTime,
				0
			);
			trans.Rotate( rotate );
		}
	}
}
