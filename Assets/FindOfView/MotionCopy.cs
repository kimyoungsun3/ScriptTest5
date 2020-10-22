using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FindOfView
{
	public class MotionCopy : MonoBehaviour
	{
		public Transform target;

		void Update()
		{
			transform.position = target.rotation * Vector3.forward * 3;
			transform.rotation = target.rotation;
		}
	}
}