using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FSMTest1{
	public class FSMTest : MonoBehaviour {
		GAME_STATE gamestate = GAME_STATE.None;
		public Text text;
		int count;

		void Start () {
			initData ();
			pInReady ();
		}
		void initData(){
			Debug.Log ("Init Game data, file load, xx");
		}

		#region xxx
		// Update is called once per frame
		void Update () {
			//Debug.Log (gamestate);
			switch (gamestate) {
			//case GAME_STATE.None:
			case GAME_STATE.Ready:
				modifyReady ();
				break;
			case GAME_STATE.Round:
				modifyRound ();
				break;
			case GAME_STATE.Gaming:
				modifyGaming ();
				break;
			case GAME_STATE.Result:
				modifyResult ();
				break;
			}
		}
		#endregion

		//----------------------
		//Ready
		//----------------------
		void pInReady(){
			gamestate = GAME_STATE.Ready;
			count = 0;
		}

		void modifyReady(){
			if (Input.GetKeyDown(KeyCode.Space)) {
				outReady ();
				return;
			}

			//~~~ unlimit run
			text.text = "Ready" + count++;
		}

		void outReady(){
			pInRound ();
		}
		//----------------------
		//Round
		//----------------------
		void pInRound(){
			gamestate = GAME_STATE.Round;
			count = 0;
		}

		void modifyRound(){
			if (Input.GetKeyDown(KeyCode.Space)) {
				pInGaming();
				return;
			}

			//~~~ unlimit run
			text.text = "Round" + count++;
		}

		#region
		//----------------------
		//Gaming
		//----------------------
		void pInGaming(){
			gamestate = GAME_STATE.Gaming;
			count = 0;
		}

		void modifyGaming(){
			if (Input.GetKeyDown(KeyCode.Space)) {
				pInResult();
				return;
			}

			//~~~ unlimit run
			text.text = "Gaming" + count++;
		}
		#endregion

		//----------------------
		//Result
		//----------------------
		void pInResult(){
			gamestate = GAME_STATE.Result;
			count = 0;
		}

		void modifyResult(){
			if (Input.GetKeyDown(KeyCode.Space)) {
				outResult ();
				return;
			}
			//~~~ unlimit run
			text.text = "Result" + count++;
		}

		void outResult(){
			Debug.Log ("Resource release");
			pInReady ();
		}
	}
}
