using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoinEat01{
	public class CoinEat : MonoBehaviour {
		protected Transform trans;
		protected Vector3 targetPos;
		protected bool bDamping;

		public virtual void SetTarget(Vector3 _pos){
			targetPos	= _pos;
			bDamping	= false;
			if (trans == null) {
				trans = transform;
			}
		}

		public virtual void SetAlive()
		{
			bDamping = true;
		}

		public virtual void PoolReturn(){
			gameObject.SetActive (false);
		}
	}
}
