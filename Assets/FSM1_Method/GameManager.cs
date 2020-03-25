using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FSM1_Method{
	public class GameManager : MonoBehaviour {
		public eGameState gamestate = eGameState.None;
		public Text text;
		int count;

		void Start () {
			InitData ();
			InReady ();
		}

		void InitData(){
			Debug.Log ("Init Game data, file load, xx");
		}

		#region xxx
		// Update is called once per frame
		void Update () {
			//Debug.Log (gamestate);
			switch (gamestate) {
			//case GAME_STATE.None:
			case eGameState.Ready:
				modifyReady ();
				break;
			case eGameState.Round:
				ModifyRound ();
				break;
			case eGameState.Gaming:
				ModifyGaming ();
				break;
			case eGameState.Result:
				ModifyResult ();
				break;
			}
		}
		#endregion

		//-----------------------------------------------------------
		//Ready
		//-----------------------------------------------------------
		void InReady()
		{
			Debug.Log("InReady >> resource read");
			gamestate	= eGameState.Ready;
			count		= 0;
		}

		void modifyReady(){
			if (Input.anyKeyDown) {
				InRound ();
				return;
			}

			//~~~ unlimit run
			text.text = "Ready" + count++;
		}

		//void outReady(){
		//	pInRound ();
		//}


		//-----------------------------------------------------------
		//Round
		//-----------------------------------------------------------
		void InRound()
		{
			Debug.Log("InRound >> resource read");
			gamestate = eGameState.Round;
			count = 0;
		}

		void ModifyRound(){
			if (Input.anyKeyDown) {
				InGaming();
				return;
			}

			//~~~ unlimit run
			text.text = "Round" + count++;
		}


		//-----------------------------------------------------------
		//Gaming
		//-----------------------------------------------------------
		void InGaming()
		{
			Debug.Log("InGaming >> resource read");
			gamestate	= eGameState.Gaming;
			count		= 0;
		}

		void ModifyGaming(){
			if (Input.anyKeyDown) {
				InResult();
				return;
			}

			//~~~ unlimit run
			text.text = "Gaming" + count++;
		}

		#region result
		//-----------------------------------------------------------
		//Result
		//-----------------------------------------------------------
		void InResult()
		{
			Debug.Log("InResult >> resource read");
			gamestate	= eGameState.Result;
			count		= 0;
		}

		void ModifyResult(){
			if (Input.anyKeyDown) {
				OutResult ();
				return;
			}
			//~~~ unlimit run
			text.text = "Result" + count++;
		}

		void OutResult()
		{
			Debug.Log ("OutResult >> Resource release");
			InReady();
		}
		#endregion // result
	}
}
