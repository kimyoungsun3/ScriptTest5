using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest3{
	[CreateAssetMenu(menuName="Pluggable/ScriptableObjectTest3/Decision/ActiveState")]
	public class DecisionActiveState : Decision {

		RaycastHit hit;
		public override bool Decide(EnemyController _c){
			return (_c.target.gameObject.activeSelf);
		}
	}
}