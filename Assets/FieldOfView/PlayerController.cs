using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FieldOfViewTest
{
	public class PlayerController : MonoBehaviour
	{
		public float moveSpeed = 2f;
		Rigidbody rigidbody;
		Camera camera;
		Transform trans;
		Vector3 move;

		// Use this for initialization
		void Start()
		{
			camera = Camera.main;
			trans = transform;
			rigidbody = GetComponent<Rigidbody>();
		}

		// Update is called once per frame
		//public Transform t;
		void Update()
		{
			//Vector3 _pos = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y));
			Vector3 _pos	= camera.ScreenToWorldPoint(Input.mousePosition);
			_pos.y			= trans.position.y;
			float _h		= Input.GetAxisRaw("Horizontal");
			float _v		= Input.GetAxisRaw("Vertical");
			move.Set(_h, 0, _v);


			trans.rotation = Quaternion.LookRotation(_pos - trans.position);
			if(_h != 0 || _v != 0)
			{
				trans.Translate(move.normalized * moveSpeed * Time.deltaTime, Space.World);
				
			}

			if(rigidbody.velocity != Vector3.zero)
			{
				rigidbody.velocity = Vector3.zero;
			}			
		}
	}
}