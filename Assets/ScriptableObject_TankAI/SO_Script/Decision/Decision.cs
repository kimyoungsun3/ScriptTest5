﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO2{
	public abstract class Decision : ScriptableObject {
		public abstract bool Decide(EnemyController _c);
	}
}
