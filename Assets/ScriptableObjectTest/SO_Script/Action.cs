﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest{
	public abstract class Action : ScriptableObject {
		public abstract void Act (ControllerState _cs);
	}
}