using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoinEat02
{
	public class CoinEat_SmoothDamp : CoinEat {

		public float dampingTime = 3f;
		Vector3 currentVelocity;

		void Update ()
		{
			if (bDamping)
			{
				trans.position = Vector3.SmoothDamp(
					trans.position, 
					targetPos,
					ref currentVelocity, 
					dampingTime);

				if(Vector3.Distance( trans.position, targetPos) < 1f)
				{
					bDamping = false;
					PoolReturn();
				}
			}
		}
	}
}
