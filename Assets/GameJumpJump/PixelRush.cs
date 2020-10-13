using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TTTTT2
{
	public class PixelRush : MonoBehaviour
	{
		private Rigidbody rb;
		BoxCollider boxCollider;
		[Range(10f, 2000f)] public float jumpPower = 300f;
		[Range(10f, 2000f)] public float spinePower = 150f;
		public LayerMask mask;
		// Start is called before the first frame update
		void Start()
		{
			rb			= GetComponent<Rigidbody>();
			boxCollider = GetComponent<BoxCollider>();
		}

		// Update is called once per frame
		void Update()
		{
			bool _bLeft		= Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
			bool _bRight	= Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
			bool _bJump		= Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) ;
			Vector3 _vel	= rb.velocity;
			_vel.z			= 5f;
			rb.velocity		= _vel;

			//Debug.DrawLine(transform.position, transform.position + Vector3.down, Color.red);
			if (Physics.Linecast(transform.position, transform.position + Vector3.down, mask))
			{
				//Quaternion _rot = transform.rotation;
				//_rot.x = Mathf.Round(_rot.x / 90) * 90;
				//transform.rotation = _rot;

				//z 한쪽회전....
				Vector3 _angle			= transform.eulerAngles;
				_angle.z				= Mathf.Round(_angle.z / 90) * 90;
				transform.eulerAngles	= _angle;
				if (_bJump)
				{
					rb.velocity = Vector3.zero;
					rb.AddForce(Vector3.up * (jumpPower * rb.mass));
					rb.AddRelativeTorque(Vector3.right * spinePower);
				}

				if (_bLeft || _bRight)
				{
					Vector3 _pos = transform.position;
					if (_bLeft && _pos.x > -1f)
					{
						// <----
						_pos.x += -1f;
						transform.position = _pos;
					}
					else if (_bRight && _pos.x < 1f)
					{
						// --->
						_pos.x += 1f;
						transform.position = _pos;
					}
				}
			}			
		}
	}
}