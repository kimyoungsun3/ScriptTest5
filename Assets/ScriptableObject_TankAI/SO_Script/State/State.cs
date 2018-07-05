using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO2;

namespace SO2{
	[CreateAssetMenu(menuName="Pluggable2/State")]
	public class State : ScriptableObject {
		
		public Action[] actions;
		public Transition[] transitions;
		public Color gizmosColor = Color.grey;
		bool bDecide;

		public void UpdateState(EnemyController _c){
			for (int i = 0; i < actions.Length; i++) {
				actions [i].Act (_c);
			}

			for (int i = 0; i < transitions.Length; i++) {
				bDecide = transitions [i].decide.Decide (_c);
				//Debug.Log (i + ":" + bDecide);
				if (bDecide) {
					_c.SetState(transitions [i].stateTrue);
				} else {
					_c.SetState(transitions [i].stateFalse);
				}
			}
		}
	}
}