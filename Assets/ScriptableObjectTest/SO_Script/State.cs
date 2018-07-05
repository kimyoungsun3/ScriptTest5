using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest{
	[CreateAssetMenu (menuName="Pluggable/ScriptableObjectTest/State")]
	public class State : ScriptableObject {
		public Action[] action;

		public void UpdateState(ControllerState _cs){
			for (int i = 0; i < action.Length; i++)
				action [i].Act (_cs);
		}
	}
}
