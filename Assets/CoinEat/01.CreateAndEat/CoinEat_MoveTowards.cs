using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoinEat01
{
	public class CoinEat_MoveTowards : CoinEat {
		public float moveSpeed = 3f;
		void Update () {

			if (bDamping)
			{
				trans.position = Vector3.MoveTowards(
					trans.position,
					targetPos,
					moveSpeed * Time.deltaTime
					);

				if (Vector3.Distance(trans.position, targetPos) < 0.01f)
				{
					bDamping = false;
					PoolReturn();
				}
			}
		}
	}
}
