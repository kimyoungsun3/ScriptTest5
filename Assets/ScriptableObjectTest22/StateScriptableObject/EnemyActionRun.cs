using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest22
{
	[CreateAssetMenu(menuName = "Pluggable/ScriptableObjectTest22/EnemyAction/Run")]
	public class EnemyActionRun : EnemyAction
	{
		public override void Act(Enemy _enemyScp, EnemyInfo _enemyInfo)
		{
			_enemyScp.trans.Translate(Vector3.forward * _enemyInfo.speed * Time.deltaTime);
		}
	}
}