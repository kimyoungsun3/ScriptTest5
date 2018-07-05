using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest{
	[CreateAssetMenu (menuName="Pluggable/ScriptableObjectTest/ActionIdle")]
	public class ActionIdle : Action {
		public override void Act(ControllerState _cs){
			Debug.Log ("ActionIdle");
		}
	}
}