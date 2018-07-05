using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest3{
	[CreateAssetMenu(menuName="Pluggable/ScriptableObjectTest3/Action/Attack")]
	public class ActionAttack : Action {

		RaycastHit hit;
		public override void Act(EnemyController _c){

			Debug.DrawRay (_c.trans.position, _c.trans.forward * _c.stateInfo.attackDistance, Color.red);
			if (Physics.Raycast (_c.trans.position, _c.trans.forward, out hit, _c.stateInfo.attackDistance, _c.stateInfo.mask)) {
				_c.Shoot ();
			}
		}
	}
}
