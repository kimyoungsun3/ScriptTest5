using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoinEat01
{
	public class CoinEat_SmoothDamp : CoinEat {

		public float dampingTime = 3f;
		//Vector3 move,
		Vector3 currentVelocity;

		void Update ()
		{
			//move	= trans.position;
			//move.x	= Mathf.SmoothDamp (move.x, targetPos.x, ref refSpeed, dampingTime);
			//move.y	= Mathf.SmoothDamp (move.y, targetPos.y, ref refSpeed, dampingTime);
			//trans.position = move;

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
