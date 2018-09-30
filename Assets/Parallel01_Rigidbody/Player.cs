using UnityEngine;
using System.Collections;

namespace Parallel01_Rigidbody{
	public class Player : MonoBehaviour {
		Rigidbody2D rb2D;
		public float angle = 45f;
		public float power = 1000f;
		Vector3 posOrginal;

		void Start(){
			posOrginal = transform.position;
			rb2D = GetComponent<Rigidbody2D> ();
			rb2D.isKinematic = true;
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetKeyDown (KeyCode.R)) {
				rb2D.isKinematic = true;
				rb2D.velocity = Vector2.zero;
				transform.position = posOrginal;
				transform.rotation = Quaternion.identity;
			} else if (Input.GetKeyDown (KeyCode.Space)) {
				rb2D.isKinematic = false;
				transform.rotation = Quaternion.Euler (Vector3.forward * angle);
				rb2D.AddForce (transform.right * power);
			}
		}

		//void OnTriggerEnter2D(Collider2D _col){
		//	if (_col.CompareTag ("Ground")) {
		//		
		//	}
		//}
	}
}
