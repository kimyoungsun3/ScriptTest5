using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest3{
	[CreateAssetMenu(menuName="Pluggable/ScriptableObjectTest3/Action/Chase")]
	public class ActionChase : Action {
		
		//Quaternion quat = Quaternion.identity;
		public override void Act(EnemyController _c){
			//move
			//Debug.Log ("Action -> Chase");
			float _distance = Vector3.Distance (_c.target.position, _c.trans.position);

			if (_distance > _c.stateInfo.limitDistance) {				
				_c.trans.position = Vector3.MoveTowards (
					_c.trans.position, 
					_c.target.position, 
					_c.stateInfo.speedChase * Time.deltaTime
				);
			}


			//rotation.
			//Quaternion _q = Quaternion.LookRotation (_c.target.position - _c.trans.position);
			//Debug.Log (_q.eulerAngles.y +":"+  _c.trans.rotation.eulerAngles.y);
			//if (!Mathf.Approximately(_q.eulerAngles.y, _c.trans.rotation.eulerAngles.y)) {
			//	//Debug.Log (" > " + _q.eulerAngles.y +":"+  _c.trans.rotation.eulerAngles.y);
			//	_c.trans.rotation = Quaternion.Lerp (_c.trans.rotation, _q, .2f);
			//}


			Quaternion _q = Quaternion.LookRotation (_c.target.position - _c.trans.position);
			_c.trans.rotation = Quaternion.RotateTowards(_c.trans.rotation, _q, _c.stateInfo.speedTurn * Time.deltaTime );

			//rotation. > 정확하지 않는다....
			// (_c.trans.rotation != quat) {
			//	quat = Quaternion.LookRotation (direction);
			//	_c.trans.rotation = Quaternion.RotateTowards (_c.trans.rotation, quat, .2f);
			//}
		}
	}
}
