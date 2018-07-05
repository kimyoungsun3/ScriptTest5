using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest{
	[CreateAssetMenu (menuName="Pluggable/ScriptableObjectTest/ActionRun")]
	public class ActionRun : Action {
		public override void Act(ControllerState _cs){
			Debug.Log ("ActionRun");
		}
	}
}