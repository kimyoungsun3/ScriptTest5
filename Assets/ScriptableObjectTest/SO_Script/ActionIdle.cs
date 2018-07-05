using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName="Pluggleable/Action/Idle")]
public class ActionIdle : Action {
	public override void Act(ControllerState _cs){
		Debug.Log ("ActionIdle");
	}
}
