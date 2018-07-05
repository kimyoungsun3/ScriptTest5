using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest3{
	[CreateAssetMenu(menuName="Pluggable/ScriptableObjectTest3/Decision/LockOnTime")]
	public class DecisionLockOnTime : Decision {
		public override bool Decide(EnemyController _c){
			return _c.CheckLockOnTime (_c.stateInfo.lockOnTime);
		}
	}
}
