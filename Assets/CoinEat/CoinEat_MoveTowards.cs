using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoinEat{
	public class CoinEat_MoveTowards : CoinEat {
		public float moveSpeed = 3f;
		void Update () {
			if (trans.position == targetPos) {
				PoolReturn ();
				return;
			}
			trans.position = Vector3.MoveTowards (trans.position, targetPos, moveSpeed * Time.deltaTime);
		}
	}
}
