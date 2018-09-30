using UnityEngine;
using System.Collections;

namespace Parallel01_Direct{
	public class Player : MonoBehaviour {
		Transform trans;
		public Vector3 gravity 		= new Vector3 (0f, -20f, 0f);
		public Vector3 KICK_POWER 	= new Vector3 (0, 20f, 0f);
		[HideInInspector] public Vector3 velocity = Vector3.zero;
		public float MOVE_SPEED = 10f;
		Rigidbody2D rb2D;
		Vector3 orgPos, beforePos;
		[HideInInspector] public bool bPause;
		public ParallerMove paraller;

		// Use this for initialization
		void Start () {
			trans = transform;
			rb2D 		= GetComponent<Rigidbody2D> ();
			orgPos 		= trans.position;

			ResetKick ();
		}

		public void ResetKick(){
			trans.position 	= orgPos;
			trans.rotation	= Quaternion.identity;
			velocity 		= Vector3.zero;

			rb2D.gravityScale 	= 0;
			rb2D.velocity 		= Vector2.zero;
			rb2D.isKinematic	= true;
			bPause 				= true;

			paraller.ResetPosition();
		}

		void PowerKick(){
			bPause 				= false;
			rb2D.isKinematic 	= false;
			velocity 			= KICK_POWER;
		}

		void PauseKick(){
			bPause = true;
		}

		//--------------------------------	
		// Update is called once per frame
		void Update () {
			if(Input.GetMouseButtonDown (0)) {
				PowerKick ();
			} else if (Input.GetMouseButtonDown (1)) {
				ResetKick ();
			}

			if (bPause) {
				return;
			}

			//1. Move
			velocity 	+= gravity * Time.deltaTime;
			velocity.x 	= MOVE_SPEED;
			beforePos 	= trans.position;
			trans.position += velocity * Time.deltaTime;

			//3. Face direct
			trans.rotation = GetQuaternionFromDir2D( trans.position - beforePos);
		}

		void OnCollisionEnter2D(Collision2D _col){	
			//Debug.Log ("OnCollisionEnter2D:"+_col.collider.name);
			if (_col.collider.CompareTag("Ground")) {
				PauseKick ();
			}
		}

		public static Quaternion GetQuaternionFromDir2D(Vector3 _viewDir)
		{
			return Quaternion.Euler(0, 0, Mathf.Atan2(_viewDir.y, _viewDir.x) * Mathf.Rad2Deg );
		}
	}
}
