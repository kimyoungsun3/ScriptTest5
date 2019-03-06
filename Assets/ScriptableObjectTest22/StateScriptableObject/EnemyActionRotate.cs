using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest22
{
	[CreateAssetMenu(menuName = "Pluggable/ScriptableObjectTest22/EnemyAction/Rotate")]
	public class EnemyActionRotate : EnemyAction
	{
		public override void Act(Enemy _enemyScp, EnemyInfo _enemyInfo)
		{
			_enemyScp.trans.Rotate(Vector3.up * _enemyInfo.turnSpeed * Time.deltaTime);
		}
	}
}