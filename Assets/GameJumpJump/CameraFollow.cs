using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TTTTT2
{
	public class CameraFollow : MonoBehaviour
	{
		public Transform target;

		void LateUpdate()
		{
			Vector3 _pos = transform.position;
			_pos.z =  target.position.z;
			transform.position = _pos;
		}
	}
}