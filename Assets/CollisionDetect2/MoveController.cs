using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {
	float speed = 5;
	Vector3 move;
	public List<Transform> list = new List<Transform>();
	public Dictionary<Transform, Vector3> dic = new Dictionary<Transform, Vector3>();

	void Start(){
		for(int i = 0; i < list.Count; i++){
			dic.Add (list [i], list [i].position);
		}
	}

	void Update () {
		move.Set (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
		transform.Translate ( move.normalized * speed * Time.deltaTime);

		if (Input.GetKeyDown (KeyCode.Space)) {
			foreach (Transform _tran in dic.Keys) {
				_tran.position = dic[_tran];
				Rigidbody _r = _tran.GetComponent<Rigidbody> ();
				if (_r != null) {
					_r.velocity = Vector3.zero;
					_r.angularVelocity = Vector3.zero;
					_tran.rotation = Quaternion.identity;
				}
			}
		}
	}
}
