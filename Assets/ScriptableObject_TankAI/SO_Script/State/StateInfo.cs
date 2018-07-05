using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO2{
	[CreateAssetMenu(menuName="Pluggable2/StateInfo")]
	public class StateInfo : ScriptableObject {
		public float speedMove = 2f;
		public float speedChase = 3f;
		public float speedTurn = 180f;

		public float seeDistance = 20f;
		public LayerMask mask;

		public float limitDistance = 2f;	//최소 지근거리...

		public float attackDistance = 10f;	//최소 어텍거리...
		public float attackRate = 1f;		//반복 사격...

		public float bulletSpeed = 20f;
		public int bulletDamage = 10;

	}
}
