using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoinEat02
{
	public class CoinEat : MonoBehaviour {
		protected Transform trans;
		protected Vector3 targetPos;
		protected bool bDamping;

		public virtual void SetTarget(Vector3 _pos,ref System.Action _onMove)
		{
			targetPos	= _pos;

			_onMove += OnSetActive;
			Debug.Log(22 + ":" + _onMove);
			bDamping = false;
			if (trans == null) {
				trans = transform;
			}
		}

		public virtual void OnSetActive()
		{
			bDamping = true;
		}

		public virtual void PoolReturn()
		{
			//onMove -= OnSetActive;
			//Debug.Log(33);
			gameObject.SetActive (false);
		}
	}
}
