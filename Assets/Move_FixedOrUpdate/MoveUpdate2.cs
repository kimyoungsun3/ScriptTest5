using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoveFixedOrUpdate{
	public class MoveUpdate2 : MonoBehaviour {
		public float moveSpeed;
		Vector3 moveDir;
		Rigidbody rb;

		void Start () {
			rb = GetComponent<Rigidbody> ();
		}

		void Update () {
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
				//transform.Translate (moveDir * moveSpeed * Time.deltaTime);
				rb.MovePosition(transform.position + moveDir * moveSpeed * Time.deltaTime);
			}
		}
	}
}
