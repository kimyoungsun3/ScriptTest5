using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FSM4{
	public class FSMAutoUpdate<T> : MonoBehaviour {
		//T 상태값...
		//Ready -> pInReady, modifyReady, outReady
		Dictionary<T, StateInfo> dicState = new Dictionary<T, StateInfo> ();
		T beforeState, currentState;//, nextState;
		VOID_FUN_VOID cbIn, cbModify, cbOut;


		public void AddState(T _t, VOID_FUN_VOID _pIn, VOID_FUN_VOID _pIng, VOID_FUN_VOID _pOut)
		{
			//Debug.Log (_t);
			if (!dicState.ContainsKey (_t)) {
				StateInfo _s = new StateInfo (_pIn, _pIng, _pOut);
				dicState.Add (_t, _s);
			} else {
				Debug.LogError (" 동일한 상태 등록" + _t);
			}
		}

		public void MoveState(T _nextState){
			//Debug.Log (_t);
			if (_nextState.Equals (currentState)) {
				return;
			} else if (!dicState.ContainsKey (_nextState)) {
				Debug.LogError ("등록되지 않는 상태 입니다." + _nextState);
				return;
			}

			//state out is callback pInOut...
			if (cbOut != null) {
				cbOut ();
			}

			//state
			beforeState 	= currentState;
			currentState 	= _nextState;
			//nextState 	= _nextState;

			//callback setting.
			StateInfo _s = dicState [_nextState];
			cbIn 		= _s.cbIn;
			cbModify 	= _s.cbModify;
			cbOut 		= _s.cbOut;

			if (cbIn != null) {
				cbIn ();
			}
		}

		void Update(){
			if (cbModify != null) {
				cbModify ();
			}
		}

		//------------------------------------------------
		class StateInfo{
			public VOID_FUN_VOID cbIn, cbModify, cbOut;
			public StateInfo(VOID_FUN_VOID _cbIn, VOID_FUN_VOID _cbModify, VOID_FUN_VOID _cbOut){
				cbIn 		= _cbIn;
				cbModify 	= _cbModify;
				cbOut 		= _cbOut;
			}
		}
	}
}