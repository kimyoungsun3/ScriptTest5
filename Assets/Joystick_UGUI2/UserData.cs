using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Joystick_UGUI2
{
	public class UserData : MonoBehaviour
	{

		public float skill1 = 1f;
		public float skill2 = 2f;
		public float skill3 = 3f;
		public float skill4 = 4f;


		public static UserData ins;
		private void Awake()
		{
			ins = this;
		}
	}
}
