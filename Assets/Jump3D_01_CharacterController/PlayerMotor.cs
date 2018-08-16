using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jump3D_01{
	[RequireComponent(typeof(CharacterController))]
	public class PlayerMotor : MonoBehaviour {
		public float gravity 	= -9.81f;
		public float jumpForce 	= 10f;
		public float moveSpeed 	= 3f;
		CharacterController controller;
		Vector3 velocity;

		void Start () {
			controller = GetComponent<CharacterController> ();
		}


		void Update () {
			//Debug.Log (controller.isGrounded);
			if (controller.isGrounded) {
				velocity.y = gravity * Time.deltaTime;
				if (Input.GetButtonDown ("Jump")) {
					velocity.y = jumpForce;
				}
			} else {
				velocity.y += gravity * Time.deltaTime;
			}

			//Keyboard move + Velocity  -> Controller move
			velocity.Set (Input.GetAxisRaw ("Horizontal") * moveSpeed, velocity.y, Input.GetAxisRaw ("Vertical") * moveSpeed);
			controller.Move (velocity * Time.deltaTime);
			
		}
	}
}