using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest4{
	[CreateAssetMenu (menuName="SO/Look")]
	public class PlayerLookSO : ScriptableObject {
		//public Vector3 ppp;

		public void Move(Player _player){
			//ppp = _player.transform.position;

			Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			float _distance;
			Vector3 _hitPoint;
			if(_player.plane.Raycast(_ray, out _distance)){
				_hitPoint = _ray.GetPoint (_distance);
				Vector3 _dir = _hitPoint - _player.transform.position;
				//transform.rotation = Quaternion.LookRotation (_dir);
				_player.transform.rotation = Util.GetQuaternionFromDir2D(_dir);
			}
		}
	}
}