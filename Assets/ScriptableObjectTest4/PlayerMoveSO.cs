using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest4{
	[CreateAssetMenu (menuName="SO/Move")]
	public class PlayerMoveSO : ScriptableObject {

		public void Move(Player _player){

			//----------------------------
			//move
			//----------------------------
			Vector3 move = Vector3.zero;
			move.Set (
				Input.GetAxisRaw ("Horizontal"),
				Input.GetAxisRaw ("Vertical"),
				0);
			_player.transform.Translate (move.normalized * _player.speed * Time.deltaTime, Space.World);


		}
	}
}
