using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraOribit
{
	public class CameraOrbit : MonoBehaviour
	{
		Vector3 input;
		public float speed = 8f;
		public float distance = 3f;
		public Transform target;
	

		// Update is called once per frame
		void Update()
		{
			input.y += Input.GetAxis("Mouse X");
			input.x -= Input.GetAxis("Mouse Y");

			Quaternion _rotation = Quaternion.Euler(input);
			transform.localPosition = target.position - _rotation * Vector3.forward * distance;
			transform.localRotation = _rotation;

		}
	}

}