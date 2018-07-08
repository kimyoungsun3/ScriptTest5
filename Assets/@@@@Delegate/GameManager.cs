using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DelegateManager{
	public class GameManager : FSMObject<GAME_STATE> {	
		public Ui_Msg uiMsg;
		int count;

		void Start () {
			AddState (GAME_STATE.Ready, 	pInReady, 	modifyReady, 	pOutReady);
			//AddState (GAME_STATE.Ready, 	pInReady, 	modifyReady, 	outReady);
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
			uiMsg.SetMsg("Ready" + count++);
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
			uiMsg.SetMsg("Round" + count++);
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
			uiMsg.SetMsg("Gaming" + count++);
			//EnemySpawner.ins
		}

		//----------------------
		//Result
		//----------------------
		void pInResult(){
			count = 0;
			uiMsg.SetMsg("Result" + count++);
		}


		void modifyResult(){
			if (Input.GetKeyDown(KeyCode.Space)) {
				MoveState (GAME_STATE.Ready);
				return;
			}
		}
	}
}
