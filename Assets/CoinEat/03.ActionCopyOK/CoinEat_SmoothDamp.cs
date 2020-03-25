using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoinEat03
{
	public class CoinEat_SmoothDamp : CoinEat {

		public float dampingTime = 3f;
		[SerializeField] float LIMIT_DISTANCE = 10f;
		Vector3 currentVelocity;

		void Update ()
		{
			if (bDamping)
			{
				trans.position = Vector3.SmoothDamp(
					trans.position, 
					target.position,
					ref currentVelocity, 
					dampingTime);

				if(Vector3.Distance( trans.position, target.position) < LIMIT_DISTANCE)
				{
					bDamping = false;
					PoolReturn();
				}
			}
		}
	}
}
