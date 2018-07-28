using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeeOfView{
	public class SOVMove : MonoBehaviour {
		public float moveSpeed = 2f;
		public float turnSpeed = 90f;

		
		// Update is called once per frame
		void Update () {
			float _h = Input.GetAxis ("Horizontal");
			float _v = Input.GetAxis ("Vertical");

			if (_v != 0) {
				transform.Translate (_v * Vector3.forward * moveSpeed * Time.deltaTime);
			}

			if (_h != 0) {
				transform.Rotate(_h * Vector3.up * turnSpeed * Time.deltaTime);
			}
		}
	}
}
