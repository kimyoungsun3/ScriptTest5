using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpJump{
	public class JumpController : MonoBehaviour {
		public float speed = 5f;
		Rigidbody rb;
		SphereCollider col;
		public LayerMask groundMask;
		public float jumpForce = 7f;
		Vector3 move;


		void Start () {
			rb = GetComponent<Rigidbody> ();
			col = GetComponent<SphereCollider> ();			
		}
		

		void Update () {
			move.Set (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));	
			rb.AddForce (move * speed);
			if (IsGround () && Input.GetKeyDown (KeyCode.Space)) {
				rb.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
			}

		}

		bool IsGround(){
			Vector3 _start = col.bounds.center;
			Vector3 _end = new Vector3 (col.bounds.center.x, col.bounds.min.y, col.bounds.center.z);
			float _radius = col.radius * .9f;
			bool _rtn = Physics.CheckCapsule (_start, _end, _radius, groundMask);

			Debug.DrawLine (_start, _end, Color.red);
			Debug.DrawRay (_start, Vector3.right * _radius, Color.green);
			Debug.DrawRay (_end, Vector3.right * _radius, Color.green);
			Debug.Log (transform.position + ":" + _rtn);
			return _rtn;
		}
	}
}
