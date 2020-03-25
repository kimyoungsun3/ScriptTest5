using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM1_Method
{
	//public enum eGameState { None, Ready, Round, Gaming, Result };
	public class GameManager4 : FSM<eGameState>
	{
		//public eGameState gameState;
		public UILabel uiMsg;
		float waitTime;
		int roundCount;
		int userA, userB;

		void Start()
		{
			AddState(eGameState.Ready,		In_Ready,	Modify_Ready,	null);
			AddState(eGameState.Round,		In_Round,	Modify_Round,	null);
			AddState(eGameState.Gaming,		In_Gaming,	Modify_Gaming,	null);
			AddState(eGameState.Pause,		In_Pause,	Modify_Pause,	null);
			AddState(eGameState.Result,		In_Result,	Modify_Result,	null);
			AddState(eGameState.Result2,	In_Result2, Modify_Result2, null);

			MoveState(eGameState.Ready);
		}

		#region Ready...
		void In_Ready()
		{
			//0. state change.
			//gameState = eGameState.Ready;

			//1. resoure read. tile message display...
			Debug.Log("In_Ready");
			uiMsg.text = gameState.ToString();
			waitTime = 2f;
		}

		void Modify_Ready()
		{
			waitTime -= Time.deltaTime;
			if(waitTime <= 0f || Input.GetKeyDown(KeyCode.Escape))
			{
				if (Input.GetKeyDown(KeyCode.Escape))
					MoveState(eGameState.Pause);
				else
					MoveState(eGameState.Round);
				return;
			}

			Debug.Log("Modify_Ready");
			//............
		}
		#endregion //ready end...

		#region Round...
		void In_Round()
		{
			//0. state change.
			if(gameState != eGameState.Result)
			{
				//유저의 처음실행...
				roundCount = 1;
				userA = 0;
				userB = 0;
			}
			gameState = eGameState.Round;
			waitTime = 2f;

			//1. resoure read. tile message display...
			Debug.Log("In_Round");
			uiMsg.text = gameState.ToString() + " : " + roundCount;
		}

		void Modify_Round()
		{
			waitTime -= Time.deltaTime;
			if (waitTime < 0f || Input.anyKeyDown)
			{
				if (Input.GetKeyDown(KeyCode.Escape))
					MoveState(eGameState.Pause);
				else
					MoveState(eGameState.Gaming);
				return;
			}

			Debug.Log("Modify_Round");
			//............
		}
		#endregion //ready end...

		#region Gaming...
		void In_Gaming()
		{
			//0. state change.
			//gameState = eGameState.Gaming;

			//1. resoure read. tile message display...
			Debug.Log("In_Gaming");
			uiMsg.text = gameState.ToString();
		}

		void Modify_Gaming()
		{
			if (Input.anyKeyDown)
			{
				if (Input.GetKeyDown(KeyCode.Escape))
				{
					MoveState(eGameState.Pause);
				}
				else
				{
					if (Input.GetMouseButtonDown(0))
					{
						userA++;
					}
					else
					{
						userB++;
					}
					roundCount++;
					if (userA >= 2 || userB >= 2)
					{
						MoveState(eGameState.Result2);
					}
					else
					{
						MoveState(eGameState.Result);
					}
				}
				return;
			}

			Debug.Log("Modify_Gaming");
			//............
		}
		#endregion //gaming end...

		#region Pause...
		void In_Pause()
		{
			//0. state change.
			//gameState = eGameState.Gaming;

			//1. resoure read. tile message display...
			Debug.Log("In_Pause");
			uiMsg.text = gameState.ToString();
		}

		void Modify_Pause()
		{
			if (Input.anyKeyDown)
			{
				MoveState(preState);
				return;
			}

			Debug.Log("Modify_Pause");
			//............
		}
		#endregion //gaming end...


		#region Result...
		void In_Result()
		{
			//0. state change.
			//gameState = eGameState.Result;

			//1. resoure read. tile message display...
			Debug.Log("In_Result");
			uiMsg.text = gameState.ToString();
			waitTime = 2f;
		}

		void Modify_Result()
		{
			waitTime -= Time.deltaTime;
			if (Input.anyKeyDown || waitTime < 0f)
			{
				MoveState(eGameState.Round);
				return;
			}

			Debug.Log("Modify_Result");
			//............
		}
		#endregion //gaming end...


		#region Result2...
		void In_Result2()
		{
			//0. state change.
			//gameState = eGameState.Result2;

			//1. resoure read. tile message display...
			Debug.Log("In_Result2");
			uiMsg.text = gameState.ToString();
		}

		void Modify_Result2()
		{
			if (Input.anyKeyDown)
			{
				MoveState(eGameState.Round);
				return;
			}

			Debug.Log("Modify_Result2");
			//............
		}
		#endregion //gaming end...


	}
}
