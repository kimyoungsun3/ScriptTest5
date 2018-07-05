using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO2{
	[CreateAssetMenu(menuName="Pluggable2/Decision/ActiveState")]
	public class DecisionActiveState : Decision {

		RaycastHit hit;
		public override bool Decide(EnemyController _c){
			return (_c.target.gameObject.activeSelf);
		}
	}
}