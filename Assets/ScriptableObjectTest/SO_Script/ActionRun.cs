using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName="Pluggleable/Action/Run")]
public class ActionRun : Action {
	public override void Act(ControllerState _cs){
		Debug.Log ("ActionRun");
	}
}
