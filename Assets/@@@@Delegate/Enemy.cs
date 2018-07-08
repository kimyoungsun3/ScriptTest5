using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DelegateManager{
	public class Enemy : MonoBehaviour {
		public System.Func<Enemy, EnemySpawner> onDeath;
		//System.Action cbIn;
		//delegate

		public void InitFirst(){

		}

		//public void 

		void Destroy(){
			onDeath = null;
			gameObject.SetActive (false);
		}
	}
}
