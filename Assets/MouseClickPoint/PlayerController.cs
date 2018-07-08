using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MouseClickPoint{
	public class PlayerController : MonoBehaviour {
		public static PlayerController ins;

		void Awake(){
			ins = this;
		}

	}
}
