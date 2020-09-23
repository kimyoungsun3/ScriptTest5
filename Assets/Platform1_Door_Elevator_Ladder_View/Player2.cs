using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform_Door_Elevator
{
	public class Player2 : MonoBehaviour
	{
		public float speed = 2f;

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			float _v = Input.GetAxisRaw("Vertical");
			float _h = Input.GetAxisRaw("Horizontal");

			Vector3 _dir = new Vector3(_h, 0, _v);
			transform.Translate(_dir.normalized * speed * Time.deltaTime);
		}
	}
}