using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest22
{
	public abstract class EnemyAction : ScriptableObject
	{
		public abstract void Act(Enemy _enemyScp, EnemyInfo _enemyInfo);
	}
}
