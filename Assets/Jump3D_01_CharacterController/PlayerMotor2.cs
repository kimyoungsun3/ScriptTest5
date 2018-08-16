using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jump3D_01{
	[RequireComponent(typeof(CharacterController))]
	public class PlayerMotor2 : MonoBehaviour {
		public float gravity 	= -9.81f;
		public float jumpForce 	= 10f;
		public float moveSpeed 	= 3f;
		//public float checkRadius = 0.01f;
		//public Transform transCheckPoint;
		//public LayerMask checkMask;
		CharacterController controller;
		Vector3 velocity;
		//bool bGround;


		void Start () {
			controller = GetComponent<CharacterController> ();
			//if (transCheckPoint == null) {
			//	transCheckPoint = transform.Find ("CheckPoint");
			//}
		}


		void Update () {
			//x
			//bGround = Physics.CheckCapsule(transform.position, transCheckPoint.position, checkRadius, checkMask);
			//x
			//bGround = Physics.Linecast(transform.position, transCheckPoint.position, checkMask);
			//x
			//bGround = Physics.Raycast(transform.position, -transform.up, checkRadius, checkMask);
			//Debug.Log (controller.isGrounded + ":" + bGround);

			velocity.y += gravity * Time.deltaTime;
			if (controller.isGrounded && Input.GetButtonDown ("Jump")) {
				velocity.y = jumpForce;
			}

			//Keyboard move + Velocity  -> Controller move
			velocity.Set (Input.GetAxisRaw ("Horizontal") * moveSpeed, velocity.y, Input.GetAxisRaw ("Vertical") * moveSpeed);
			controller.Move (velocity * Time.deltaTime);
			
		}
	}
}