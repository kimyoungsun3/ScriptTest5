using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest{
	public class ControllerState : MonoBehaviour {
		public State stateInfo;
		public State stateInfo2;

		private void Start()
		{
			Debug.Log(this + " >> " + (stateInfo == stateInfo2));
		}

		private void Update()
		{
			if (stateInfo != null)
				stateInfo.UpdateState(this);
		}

		//public State stateInfo;
		//private void Update()
		//{
		//	if (stateInfo != null)
		//		stateInfo.UpdateState(this);
		//}


		//public static Dictionary<State, State> dic = new Dictionary<State, State>();
		//public static List<State> list = new List<State>();

		//public State stateInfo;
		//public State stateInfo2;

		//private void Start()
		//{
		//	Debug.Log(this + ":" + (stateInfo == stateInfo2));
		//	AddDic(stateInfo);
		//	AddDic(stateInfo2);
		//}

		//void AddDic(State _s)
		//{
		//	if (!dic.ContainsKey(_s))
		//	{
		//		dic.Add(_s, _s);
		//	}
		//	else
		//	{
		//		Debug.Log("Exists");
		//	}
		//	list.Add(_s);
		//}

		//private void Update()
		//{
		//	Debug.Log("dic:" + dic.Count + " list:" + list.Count);
		//	if (stateInfo != null)
		//		stateInfo.UpdateState(this);
		//}

		//public State stateInfo;
		////public State stateInfo2;

		////private void Start()
		////{
		////	Debug.Log(stateInfo == stateInfo2);
		////}

		//void Update () {
		//	if (stateInfo != null) {
		//		stateInfo.UpdateState (this);
		//	}
		//}
	}
}
