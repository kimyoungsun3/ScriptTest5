using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest{
	public class ControllerState : MonoBehaviour {
		public State stateInfo;
		
		void Update () {
			if (stateInfo != null) {
				stateInfo.UpdateState (this);
			}
		}
	}
}
