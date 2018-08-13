using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FSM4_Delegate{
	public class FSMTest : FSMAutoUpdate<GAME_STATE> {
		public Text text;
		int count;
		// Use this for initialization
		void Start () {
			AddState (GAME_STATE.Ready, 	pInReady, 	modifyReady, 	pOutReady);
			AddState (GAME_STATE.Round, 	pInRound, 	modifyRound, 	null);
			AddState (GAME_STATE.Gaming, 	pInGaming, 	modifyGaming, 	null);
			AddState (GAME_STATE.Result, 	pInResult, 	modifyResult, 	null);

			MoveState (GAME_STATE.Ready);
		}

		//----------------------
		//Ready
		//----------------------
		void pInReady(){
			count = 0;
		}

		void modifyReady(){
			if (Input.GetKeyDown(KeyCode.Space)) {
				MoveState (GAME_STATE.Round);
				return;
			}

			//~~~ unlimit run
			text.text = "Ready" + count++;
		}

		void pOutReady(){
			count = -1000;
		}

		//----------------------
		//Round
		//----------------------
		void pInRound(){
			count = 0;
		}

		void modifyRound(){
			if (Input.GetKeyDown(KeyCode.Space)) {
				MoveState (GAME_STATE.Gaming);
				return;
			}

			//~~~ unlimit run
			text.text = "Round" + count++;
		}

		//----------------------
		//Gaming
		//----------------------
		void pInGaming(){
			count = 0;
		}

		void modifyGaming(){
			if (Input.GetKeyDown(KeyCode.Space)) {
				MoveState (GAME_STATE.Result);
				return;
			}

			//~~~ unlimit run
			text.text = "Gaming" + count++;
		}

		//----------------------
		//Result
		//----------------------
		void pInResult(){
			count = 0;
			text.text = "Result";
		}


		void modifyResult(){
			if (Input.GetKeyDown(KeyCode.Space)) {
				MoveState (GAME_STATE.Ready);
				return;
			}
		}
	}
}