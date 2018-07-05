using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest2{
	public class Enemy : MonoBehaviour {
		public EnemyInfoSO infoSO;
		bool bRefresh = true;
		public TextMesh text;


		void Update(){
			if (bRefresh) {
				bRefresh = !bRefresh;
				text.text = infoSO.health + "/" + infoSO.speed;
			}
		}

		public void OnMouseDown(){
			infoSO.health += 1;
			infoSO.speed += 1;
			bRefresh = true;
			Debug.Log (this + ":" + infoSO.ToString ());
		}
	}
}
