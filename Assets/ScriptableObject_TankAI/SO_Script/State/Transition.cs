using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO2{
	[System.Serializable]
	public class Transition {
		public Decision decide;
		public State stateTrue, stateFalse;
	}
}