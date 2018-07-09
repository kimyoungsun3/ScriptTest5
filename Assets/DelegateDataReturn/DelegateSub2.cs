using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DelegateDataReturn{
	public class DelegateSub2 : MonoBehaviour {
		System.Action<string> callbackHitKey;

		public void InitFirst(System.Action<string> _cb){
			callbackHitKey = _cb;
		}


		void Update () {
			if (Input.anyKeyDown) {
				if (callbackHitKey != null) {
					callbackHitKey (Input.inputString);
					callbackHitKey = null;
				}
			}
		}
	}
}
