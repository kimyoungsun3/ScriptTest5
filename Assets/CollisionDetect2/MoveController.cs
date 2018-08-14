using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CollisionDetect2{
	public class MoveController : MonoBehaviour {
		public float speed = 5f;
		Vector3 move;
		public List<Transform> list = new List<Transform>();
		public Dictionary<Transform, Vector3> dic = new Dictionary<Transform, Vector3>();
		Rigidbody rigidbody;

		void Start(){
			for(int i = 0; i < list.Count; i++){
				dic.Add (list [i], list [i].position);
			}

			rigidbody = GetComponent<Rigidbody> ();
		}

		void Update () {
			move.Set (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
			move = move.normalized * speed * Time.deltaTime;
			if (rigidbody != null)
				rigidbody.MovePosition ( rigidbody.position + move );
			else
				transform.Translate ( move );

			//---------------------------------------------
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				foreach (Transform _tran in dic.Keys) {
					_tran.position = dic [_tran];
					Rigidbody _r = _tran.GetComponent<Rigidbody> ();
					if (_r != null) {
						_r.velocity = Vector3.zero;
						_r.angularVelocity = Vector3.zero;
						_tran.rotation = Quaternion.identity;
					}
				}
			} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
				Debug.Log ("===========================");
			}
		}
	}
}
