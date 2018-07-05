using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO2{
	[CreateAssetMenu(menuName="Pluggable2/Action/Attack")]
	public class ActionAttack : Action {

		RaycastHit hit;
		public override void Act(EnemyController _c){

			if (Physics.Raycast (_c.trans.position, _c.trans.forward, out hit, _c.stateInfo.attackDistance, _c.stateInfo.mask)
				&& _c.CheckAttackTime (_c.stateInfo.attackRate)) {
				_c.Shoot ();
			}
		}
	}
}
