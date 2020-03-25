using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoinEat03
{
	public class CoinEat : MonoBehaviour {
		protected Transform trans;
		protected Transform target;
		protected bool bDamping;
		MouseClick scpMouseClick;

		public virtual void SetTarget(Transform _target, MouseClick _scpMouseClick)
		{
			target			= _target;
			scpMouseClick	= _scpMouseClick;

			scpMouseClick.onAllEat += OnSetActive;
			bDamping = false;
			if (trans == null) {
				trans = transform;
			}
		}

		public virtual void OnSetActive()
		{
			//Debug.Log(this + " OnSetActive");
			bDamping = true;
		}

		public virtual void PoolReturn()
		{
			if (scpMouseClick != null)
			{
				scpMouseClick.onAllEat -= OnSetActive;
			}

			gameObject.SetActive (false);
		}
	}
}
