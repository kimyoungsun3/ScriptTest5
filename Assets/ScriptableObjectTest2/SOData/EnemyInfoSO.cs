using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest2{
	[CreateAssetMenu(menuName="ScriptableObjectTest2/EnemyInfoSO")]
	public class EnemyInfoSO : ScriptableObject {
		public float health = 2f;
		public float speed = 10f;

		public override string ToString ()
		{
			return string.Format ("[EnemyInfoSO] {0}, {1}", health, speed);
		}
	}
}
