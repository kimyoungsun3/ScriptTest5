using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest22
{
	[CreateAssetMenu(menuName = "Pluggable/ScriptableObjectTest22/EnemyInfo")]
	public class EnemyInfo : ScriptableObject
	{
		public EnemyAction[] acts;
		public float hp;
		public float speed;
		public float turnSpeed;

		public void UpdateState(Enemy _enemyScp)
		{
			for (int i = 0; i < acts.Length; i++)
			{
				acts[i].Act(_enemyScp, this);
			}
		}
	}
}
