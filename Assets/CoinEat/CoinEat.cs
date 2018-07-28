using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoinEat{
	public class CoinEat : MonoBehaviour {
		protected Vector3 targetPos;
		protected Transform trans;

		public virtual void InitFirst(Vector3 _pos){
			targetPos = _pos;
			if (trans == null) {
				trans = transform;
			}
		}

		public virtual void PoolReturn(){
			gameObject.SetActive (false);
		}
	}
}
