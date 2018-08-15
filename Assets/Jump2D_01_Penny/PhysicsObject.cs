using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jump2D_01{
	public class PhysicsObject : MonoBehaviour {
		public float minGroundNormalY = 0.65f;
		public Vector2 gravity = new Vector2(0, -9.81f);

		protected Vector2 targetVelocity;
		protected Vector2 velocity;

		protected bool grounded;
		protected Vector2 groundNormal;
		protected Rigidbody2D rb2d;
		protected ContactFilter2D contactFilter;
		protected RaycastHit2D[] hitBuffer 			= new RaycastHit2D[16];
		protected List<RaycastHit2D> hitBufferList 	= new List<RaycastHit2D> (16);

		protected const float minMoveDistance = 0.001f;
		protected const float shellRadius = 0.01f;

		void OnEnable(){
			//Debug.Log (11);
			rb2d = GetComponent<Rigidbody2D> ();	
			//Debug.Log (rb2d);
		}

		void Start(){
			//Debug.Log (22);
			contactFilter.useTriggers = false;
			contactFilter.SetLayerMask (Physics2D.GetLayerCollisionMask (gameObject.layer));
			contactFilter.useLayerMask = true;

			//Debug.Log ("gameObject.layer:" + gameObject.layer
			//	+ " > " + Physics2D.GetLayerCollisionMask (gameObject.layer));
		}


		void Update()
		{
			//Debug.Log (33);
			targetVelocity = Vector2.zero;
			ComputeVelocity ();
		}

		protected virtual void ComputeVelocity(){}

		void FixedUpdate()
		{
			//Debug.Log (55);
			//Debug.Log (Physics2D.gravity); -9.8
			velocity += gravity * Time.deltaTime;
			velocity.x = targetVelocity.x;
			grounded = false;

			Vector2 _deltaPosition = velocity * Time.deltaTime;
			Vector2 _moveAlongGround = new Vector2 (groundNormal.y, -groundNormal.x);
			Vector2 _move = _moveAlongGround * _deltaPosition.x;

			//Debug.Log ("---------x----------");
			Movement (_move, false);
			_move = Vector2.up * _deltaPosition.y;
			//Debug.Log ("---------y---------");
			Movement (_move, true);
		}

		void Movement(Vector2 _move, bool _yMovement){
			float _distance = _move.magnitude;

			if (_distance > minMoveDistance) {
				int _count = rb2d.Cast (_move, contactFilter, hitBuffer, _distance + shellRadius);
				hitBufferList.Clear ();
				for (int i = 0; i < _count; i++) {
					hitBufferList.Add (hitBuffer [i]);
				}

				for (int i = 0; i < hitBufferList.Count; i++) {
					Vector2 _currentNormal = hitBufferList [i].normal;
					if (_currentNormal.y > minGroundNormalY) {
						grounded = true;
						if (_yMovement) {
							groundNormal = _currentNormal;
							_currentNormal.x = 0;
						}
					}

					if(_yMovement){
						float _projection = Vector2.Dot (velocity, _currentNormal);
						if (_projection < 0) {
							velocity -= _projection * _currentNormal;
							//Debug.Log (" > " + _projection);
						}
					}

					float _modifiedDistance = hitBufferList [i].distance - shellRadius;
					_distance = _modifiedDistance < _distance ? _modifiedDistance : _distance;
				}
			}

			rb2d.position += _move.normalized * _distance;
		}
	}
}