using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoinEat{
	public class CoinEat_SmoothDamp : CoinEat {

		public float smoothTime = 3f;
		Vector3 move;
		float refSpeed;

		void Update () {
			//if(Vector3.Distance(trans.position, targetPos) < 0.1f){
			if (trans.position == targetPos) {
				PoolReturn ();
				return;
			}

			move = trans.position;
			move.x = Mathf.SmoothDamp (move.x, targetPos.x, ref refSpeed, smoothTime);
			move.y= Mathf.SmoothDamp (move.y, targetPos.y, ref refSpeed, smoothTime);
			trans.position = move;
		}
	}
}
