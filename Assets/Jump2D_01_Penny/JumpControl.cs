using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jump2D_01{
	public class JumpControl : PhysicsObject {
		public float maxSpeed = 7;
		public float jumpTakeOffSpeed = 7;

		private SpriteRenderer spriteRenderer;
		private Animator animator;
		Vector3 move;

		// Use this for initialization
		void Awake () 
		{
			spriteRenderer 	= GetComponent<SpriteRenderer> (); 
			animator 		= GetComponent<Animator> ();
		}

		//-----------------------------------
		protected override void ComputeVelocity()
		{
			//Debug.Log (Time.timeScale);
			//Debug.Log (spriteRenderer.flipX);
			//--------------------------
			// Left - Right move > get
			//--------------------------
			//if (btnJoystick.InputVector != Vector3.zero) {
			//	//Joystick 
			//	move = btnJoystick.InputVector;
			//} else 
			{
				//Keyboard (move)
				move.Set (Input.GetAxis ("Horizontal"), 0, 0);
			}


			//--------------------------
			// Jump, 
			//--------------------------
			//if ((uiBtnRight.GetJumpDown() || Input.GetButtonDown("Jump")) && grounded) {
			//	velocity.y = jumpTakeOffSpeed;
			//} else if (uiBtnRight.GetJumpUp()|| Input.GetButtonUp("Jump")) {
			//	if (velocity.y > 0) {
			//		velocity.y = velocity.y * 0.5f;
			//	}
			//}
			//Debug.Log (grounded);
			if (Input.GetButtonDown("Jump") && grounded) {
				//Debug.Log (" > jump"); 
				velocity.y = jumpTakeOffSpeed;
			//} else if (Input.GetButtonUp("Jump")) {
			//	if (velocity.y > 0) {
			//		velocity.y = velocity.y * 0.5f;
			//	}
			}

			//-------------------------------------------
			if(move.x > 0.01f)
			{
				if(spriteRenderer.flipX == true)
				{
					spriteRenderer.flipX = false;
				}
			} 
			else if (move.x < -0.01f)
			{
				if(spriteRenderer.flipX == false)
				{
					spriteRenderer.flipX = true;
				}
			}

			animator.SetBool ("grounded", grounded);
			animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);

			targetVelocity = move * maxSpeed;
		}
	}
}
