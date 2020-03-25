using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FSM2_Delegate{
	public class FSMTest : FSMObject<eGameState> {	
		public Text text;
		int count;
		// Use this for initialization
		void Start () {
			AddState (eGameState.Ready, 	pInReady, 	modifyReady, 	pOutReady);
			//AddState (GAME_STATE.Ready, 	pInReady, 	modifyReady, 	outReady);
			AddState (eGameState.Round, 	pInRound, 	modifyRound, 	null);
			AddState (eGameState.Gaming, 	pInGaming, 	modifyGaming, 	null);
			AddState (eGameState.Result, 	pInResult, 	modifyResult, 	null);

			MoveState (eGameState.Ready);
		}

		//-----------------------------------------------------------
		//Ready
		//-----------------------------------------------------------
		void pInReady(){
			count = 0;
		}

		void modifyReady(){
			if (Input.anyKeyDown) {
				MoveState (eGameState.Round);
				return;
			}

			//~~~ unlimit run
			text.text = "Ready" + count++;
		}

		void pOutReady(){
			count = -1000;
		}

		//-----------------------------------------------------------
		//Round
		//-----------------------------------------------------------
		void pInRound(){
			count = 0;
		}

		void modifyRound(){
			if (Input.anyKeyDown) {
				MoveState (eGameState.Gaming);
				return;
			}

			//~~~ unlimit run
			text.text = "Round" + count++;
		}

		//-----------------------------------------------------------
		//Gaming
		//-----------------------------------------------------------
		void pInGaming(){
			count = 0;
		}

		void modifyGaming(){
			if (Input.anyKeyDown) {
				MoveState (eGameState.Result);
				return;
			}

			//~~~ unlimit run
			text.text = "Gaming" + count++;
		}

		//-----------------------------------------------------------
		//Result
		//-----------------------------------------------------------
		void pInResult(){
			count = 0;
			text.text = "Result";
		}


		void modifyResult(){
			if (Input.anyKeyDown) {
				MoveState (eGameState.Ready);
				return;
			}
		}
	}
}