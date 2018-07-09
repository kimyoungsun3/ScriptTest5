using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DelegateManager{
	public class EnemyBullet : MonoBehaviour {
		Enemy scpEnemy;

		public void InitFirst(Enemy _e){
			scpEnemy = _e;
		}

		void Update(){
			if (Input.GetKeyDown (KeyCode.Alpha6)) {
				int _r = Random.Range (0, 100);
				//Debug.Log (_r);
				if (_r < 50) {
					HitAndDestroy ();
				}
			}
		}

		public void HitAndDestroy(){
			scpEnemy.DelEnemyBullet (this);
			Destroy ();
		}

		public void Destroy(){
			gameObject.SetActive (false);
		}
	}
}