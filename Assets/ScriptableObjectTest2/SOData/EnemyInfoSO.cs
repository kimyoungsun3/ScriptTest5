using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest2{
	[CreateAssetMenu(menuName="Pluggable/ScriptableObjectTest2/EnemyInfoSO")]
	public class EnemyInfoSO : ScriptableObject
	{
		public float health = 100f;
		public float speed = 5f;
		public override string ToString()
		{
			return string.Format("hp:{0}, speed:{1}", health, speed);
		}
	}
	
	//public class EnemyInfoSO : ScriptableObject {
	//	public float health = 2f;
	//	public float speed = 10f;

	//	public override string ToString ()
	//	{
	//		return string.Format ("[EnemyInfoSO] {0}, {1}", health, speed);
	//	}
	//}
}
