using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM6{
	public class FSMData<T>{
		public T t;
		public System.Action cbIn;
		public System.Action cbLoop;
		public System.Action cbOut;
	}

	public class FSM<T> : MonoBehaviour{
		Dictionary<T, FSMData<T>> dicFun = new Dictionary<T, FSMData<T>>();
		[HideInInspector] public T preState = default(T);
		[HideInInspector] public T gameState = default(T);
		[HideInInspector] public T nextState = default(T);

		System.Action cbIn;
		System.Action cbLoop;
		System.Action cbOut;

		protected void InitState(T _t){
			gameState = _t;
		}

		public void AddState(T _t, System.Action _cbIn, System.Action _cbOut){
			AddState (_t, _cbIn, null, _cbOut);
		}

		public void AddState(T _t, System.Action _cbIn, System.Action _cbLoop, System.Action _cbOut){
			if (dicFun.ContainsKey (_t)) {
				Debug.LogError ("Already added state");
			} else {
				FSMData<T> _data = new FSMData<T> ();
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
			}
			else if (gameState.Equals(_nextState))
			{
				return;
			}

			//state out is callback pInOut...
			if (cbOut != null) {
				cbOut ();
			}

			//state
			preState 	= gameState;
			gameState 	= _nextState;
			nextState 	= _nextState;

			//callback setting
			FSMData<T> _s = dicFun[gameState];
			cbIn 	= _s.cbIn;
			cbLoop	= _s.cbLoop;
			cbOut 	= _s.cbOut;

			//pIn start
			if (cbIn != null) {
				cbIn ();
			}
		}

		void Update(){
			Debug.Log ("gameState:" + gameState);
			if (cbLoop != null) {
				cbLoop ();
			}
		}
	}
}