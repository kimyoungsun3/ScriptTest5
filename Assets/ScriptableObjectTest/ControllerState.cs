using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerState : MonoBehaviour {
	public State stateInfo;
	
	void Update () {
		if (stateInfo != null) {
			stateInfo.UpdateState (this);
		}
	}
}
