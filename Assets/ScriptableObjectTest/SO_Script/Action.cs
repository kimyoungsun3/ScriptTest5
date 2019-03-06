using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest{
	public abstract class Action : ScriptableObject
	{
		public abstract void Act(ControllerState _monoScp);
	}
	
	//public abstract class Action : ScriptableObject {
	//	public abstract void Act (ControllerState _cs);
	//}

	//public abstract class Action5 : ScriptableObject
	//{
	//	public abstract void Act(MonoBehaviour _scp);
	//}

	//public abstract class Action4 : ScriptableObject
	//{
	//	public abstract void Act(MonoBehaviour _scp);
	//}

	//public abstract class Action3 : ScriptableObject
	//{
	//	public abstract void Act(MonoBehaviour _scp);
	//}

	//public abstract class Action2 : ScriptableObject
	//{
	//	public abstract void Act(ControllerState _cs);
	//}

	//public abstract class Action : ScriptableObject
	//{
	//	public abstract void Act(ControllerState _cs);
	//}
}