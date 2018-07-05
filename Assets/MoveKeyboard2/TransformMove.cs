using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMove : MonoBehaviour {
	public enum State_Move{ Direction, TransformFun};
	public State_Move state = State_Move.Direction;
	public float speedMove = 3f;
	public float speedTurn = 180f;
	Transform trans;
	float h, v;
	Rigidbody rb;

	void Start(){
		trans = transform;
		rb = GetComponent<Rigidbody> ();
	}
	
	void Update () {
		h = Input.GetAxisRaw ("Horizontal");
		v = Input.GetAxisRaw ("Vertical");

		if (v != 0) {
			switch (state) {
			case State_Move.Direction:
				trans.position	+= v * trans.forward * speedMove * Time.deltaTime;
				//C   -> 통과.....
				//C+R -> 물속성...
				break;
			case State_Move.TransformFun:
				trans.Translate (v * Vector3.forward * speedMove * Time.deltaTime);
				//C   -> 통과.....
				//C+R -> 물속성...
				break;
			}
		}

		if (h != 0) {
			trans.Rotate (h*Vector3.up * speedTurn * Time.deltaTime);
		}

		if (v == 0 && h == 0 && (rb.velocity != Vector3.zero || rb.angularVelocity != Vector3.zero)) {
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}
		//Debug.Log (v + ":" + h + ":" + rb.velocity + ":" + rb.angularVelocity);
	}
}
