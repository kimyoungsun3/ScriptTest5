using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest3{
	public abstract class Decision : ScriptableObject {
		public abstract bool Decide(EnemyController _c);
	}
}
