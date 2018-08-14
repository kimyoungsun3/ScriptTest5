using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CollisionDetect{
	public enum MoveType{TramsformTranslate, RigidbodyMovePosition}
	public class ObjectMove : MonoBehaviour {		
		public MoveType moveType = MoveType.RigidbodyMovePosition;

		public float speed = 3f;
		Rigidbody rigidbody;
		Vector3 move;

		void Start () {
			rigidbody = GetComponent<Rigidbody> ();
		}

		void Update () {
			move.Set (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
			move = move.normalized * speed * Time.deltaTime;
			if (moveType == MoveType.TramsformTranslate) {
				transform.Translate(move, Space.World);
			} else {
				rigidbody.MovePosition (rigidbody.position + move);
			}
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
		}
	}
}
