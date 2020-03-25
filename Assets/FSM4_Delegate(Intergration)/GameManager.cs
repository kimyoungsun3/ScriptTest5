using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FSM4{
	public class FSMTest : FSMAutoUpdate<eGameState> {
		public Text text;
		int count;
		// Use this for initialization
		void Start () {
			AddState (eGameState.Ready, 	pInReady, 	modifyReady, 	pOutReady);
			AddState (eGameState.Round, 	pInRound, 	modifyRound, 	null);
			AddState (eGameState.Gaming, 	pInGaming, 	modifyGaming, 	null);
			AddState (eGameState.Result, 	pInResult, 	modifyResult, 	null);

			MoveState (eGameState.Ready);
		}

		//----------------------
		//Ready
		//----------------------
		void pInReady(){
			count = 0;
		}

		void modifyReady(){
			if (Input.GetKeyDown(KeyCode.Space)) {
				MoveState (eGameState.Round);
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
				MoveState (eGameState.Gaming);
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
				MoveState (eGameState.Result);
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
				MoveState (eGameState.Ready);
				return;
			}
		}
	}
}