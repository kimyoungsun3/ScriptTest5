using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmData<T>{
	public T t;
	public System.Action cbIn;
	public System.Action cbLoop;
	public System.Action cbOut;
}

public class Fsm<T> : MonoBehaviour{
	Dictionary<T, FsmData<T>> dicFun = new Dictionary<T, FsmData<T>>();
	protected T preState = default(T);
	protected T curState = default(T);
	protected T nextState = default(T);

	System.Action cbIn;
	System.Action cbLoop;
	System.Action cbOut;

	protected void InitState(T _t){
		curState = _t;
	}

	public void AddState(T _t, System.Action _cbIn, System.Action _cbOut){
		AddState (_t, _cbIn, null, _cbOut);
	}

	public void AddState(T _t, System.Action _cbIn, System.Action _cbLoop, System.Action _cbOut){
		if (dicFun.ContainsKey (_t)) {
			Debug.LogError ("Already added state");
		} else {
			FsmData<T> _data = new FsmData<T> ();
			_data.t 	= _t;
			_data.cbIn 	= _cbIn;
			_data.cbLoop= _cbLoop;
			_data.cbOut = _cbOut;
			dicFun.Add (_t, _data);
		}
	}

	public void MoveState(T _nextState){
		if (!dicFun.ContainsKey (_nextState)) {
			Debug.LogError ("I don't know " + _nextState);
			return;
		//} else if (curState == _nextState) {
		//	return;
		}

		//state out is callback pInOut...
		if (cbOut != null) {
			cbOut ();
		}

		//state
		preState 	= curState;
		curState 	= _nextState;
		nextState 	= _nextState;

		//callback setting
		FsmData<T> _s = dicFun[curState];
		cbIn 	= _s.cbIn;
		//cbLoop= _s.cbLoop;
		cbOut 	= _s.cbOut;

		//pIn start
		if (cbIn != null) {
			cbIn ();
		}
	}
}
