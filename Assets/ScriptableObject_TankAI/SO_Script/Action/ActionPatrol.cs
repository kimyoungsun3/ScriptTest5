using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO2{
	[CreateAssetMenu(menuName="Pluggable2/Action/Patrol")]
	public class ActionPatrol : Action {
		//public int count = 0;
		public override void Act(EnemyController _c){
			//count++;
			//Debug.Log (count);

			//move
			//Debug.Log (_c.wayIndex + ":" + _c.wayWorld.Length);
			if (_c.trans.position == _c.wayWorld [_c.wayIndex]) {
				_c.wayIndex = (_c.wayIndex + 1) % _c.wayWorld.Length;
			}
			_c.trans.position = Vector3.MoveTowards (_c.trans.position, 
				_c.wayWorld [_c.wayIndex], 
				_c.stateInfo.speedMove * Time.deltaTime);

			//rotation.
			Vector3 _dir = _c.wayWorld [_c.wayIndex] - _c.trans.position;
			if (_dir != Vector3.zero) {
				Quaternion _q = Quaternion.LookRotation (_dir);
				_c.trans.rotation = Quaternion.Lerp (_c.trans.rotation, _q, .2f);
			}
		}
	}
}