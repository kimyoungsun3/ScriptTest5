using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest3{
	[CreateAssetMenu(menuName="Pluggable/ScriptableObjectTest3/Decision/Look")]
	public class DecisionLook : Decision {

		RaycastHit hit;
		public override bool Decide(EnemyController _c){


			if(Physics.Raycast(_c.trans.position, _c.trans.forward, out hit, _c.stateInfo.seeDistance, _c.stateInfo.mask)){
				_c.SetTargeting(hit.transform);
				return true;
			}else{
				return false;
			}
		}
	}
}