using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO2{
	public abstract class Action : ScriptableObject {
		public abstract void Act(EnemyController _c);
	}

}