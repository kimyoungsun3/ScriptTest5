using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoveBase{
	public class MoveKeyboard : MonoBehaviour {
		public enum MOVE_MODE{Translate, Direction};
		public float speed = 3f;
		public float turnSpeed = 30f;
		public MOVE_MODE mode = MOVE_MODE.Translate;
		Transform trans;
		Rigidbody rb;
		float h, v;
		Vector3 worldForward, worldUp, zero;

		void Start () {
			trans 	= transform;
			rb		= GetComponent<Rigidbody> ();
			worldForward = Vector3.forward;
			worldUp	= Vector3.up;
			zero = Vector3.zero;
		}

		void Update () {
			v = Input.GetAxisRaw ("Vertical");
			h = Input.GetAxisRaw ("Horizontal");

			if (mode == MOVE_MODE.Translate) {
				if (v != 0) {
					trans.Translate (v * worldForward * speed * Time.deltaTime);
					//move -> rigidbody OK
				}
			} else {
				if (v != 0) {
					//move -> rig X 마찰회전 > 이상함...
					//떨림이 있다.... 음....
					// > 이버젼에서 이상하게 작동함....
					trans.position += v * trans.forward * speed * Time.deltaTime;
				}
			}
			trans.Rotate (worldUp * h * turnSpeed * Time.deltaTime);

			/*
			//Debug.Log (v + ":" + h + ":" + rb.velocity + ":" + rb.angularVelocity);
			if (rb != null && (rb.velocity != zero || rb.angularVelocity != zero)) {
				rb.velocity = zero;
				rb.angularVelocity = zero;
			}
			*/

		}
	}
}
