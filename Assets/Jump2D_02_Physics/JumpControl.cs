using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jump2D_02{
	public class JumpControl : MonoBehaviour {
		public float moveForce 	= 365f;			// Amount of force added to move the player left and right.
		public float maxSpeed 	= 5f;				// The fastest the player can travel in the x axis.
		public float jumpForce = 1000f;			// Amount of force added when the player jumps.

		Animator animator;
		Rigidbody2D rb2d;
		bool grounded = false;
		bool bJump;
		bool facingRight = true;			// For determining which way the player is currently facing.
		public Transform transGround;
		public LayerMask groundMask;

		//--------------------------------
		void Start () {
			animator	= GetComponent<Animator> ();
			rb2d 		= GetComponent<Rigidbody2D> ();
		}

		void Update () {
			//1. Input key.
			grounded = Physics2D.Linecast (transform.position, transGround.position, groundMask);
			if (Input.GetButtonDown ("Jump") && grounded) {
				bJump = true;
			}
		}

		void FixedUpdate(){
			float h = Input.GetAxis("Horizontal");

			// The Speed animator parameter is set to the absolute value of the horizontal input.
			animator.SetFloat ("velocityX", Mathf.Abs (h));

			// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
			if (h * rb2d.velocity.x < maxSpeed) {
				rb2d.AddForce (Vector2.right * h * moveForce);
			}

			// If the player's horizontal velocity is greater than the maxSpeed...
			if (Mathf.Abs (rb2d.velocity.x) > maxSpeed) {
				rb2d.velocity = new Vector2 (
					Mathf.Sign (rb2d.velocity.x) * maxSpeed, 
					rb2d.velocity.y
				);
			}
			
			if(h > 0 && !facingRight)
				Flip();
			else if(h < 0 && facingRight)
				Flip();

			if(bJump)
			{
				animator.SetTrigger("Jump");

				// Add a vertical force to the player.
				rb2d.AddForce(new Vector2(0f, jumpForce));

				// Make sure the player can't jump again until the jump conditions from Update are satisfied.
				bJump = false;
			}
		}

		void Flip ()
		{
			// Switch the way the player is labelled as facing.
			facingRight = !facingRight;

			// Multiply the player's x local scale by -1.
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}

		//--------------------------------
		void OnCollisionEnter2D(Collision2D _col){	
			Debug.Log ("OnTriggerEnter2D:" +  _col.collider.name);
		}

		void OnTriggerEnter2D(Collider2D _col){
			Debug.Log ("OnTriggerEnter2D:" +  _col.name);
		}
	}
}
