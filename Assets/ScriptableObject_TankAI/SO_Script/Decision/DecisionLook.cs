using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO2{
	[CreateAssetMenu(menuName="Pluggable2/Decision/Look")]
	public class DecisionLook : Decision {

		RaycastHit hit;
		public override bool Decide(EnemyController _c){

			if(Physics.Raycast(_c.trans.position, _c.trans.forward, out hit, _c.stateInfo.seeDistance, _c.stateInfo.mask)){
				_c.target = hit.transform;
				return true;
			}else{
				return false;
			}
		}
	}
}