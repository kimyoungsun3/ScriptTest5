using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM1_Method
{
	public enum eGameState { None, Ready, Round, Gaming, Result, Result2, Pause };
	public class GameManager2 : MonoBehaviour
	{
		public eGameState gameState;
		public UILabel uiMsg;
		float waitTime;

		void Start()
		{
			In_Ready();
		}

		#region Ready...
		void In_Ready()
		{
			//0. state change.
			gameState = eGameState.Ready;

			//1. resoure read. tile message display...
			Debug.Log("In_Ready");
			uiMsg.text = gameState.ToString();
			waitTime = 2f;
		}

		void Modify_Ready()
		{
			waitTime -= Time.deltaTime;
			if(waitTime <= 0f)
			{
				Out_Ready();
				return;
			}

			Debug.Log("Modify_Ready");
			//............
		}

		void Out_Ready()
		{
			Debug.Log("Out_Ready");
			//리소스 해제...
			//다음상태로 전이....
			In_Round();
		}
		#endregion //ready end...

		#region Round...
		void In_Round()
		{
			//0. state change.
			gameState = eGameState.Round;

			//1. resoure read. tile message display...
			Debug.Log("In_Round");
			uiMsg.text = gameState.ToString();
		}

		void Modify_Round()
		{
			if (Input.anyKeyDown)
			{
				In_Gaming();
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
			gameState = eGameState.Gaming;

			//1. resoure read. tile message display...
			Debug.Log("In_Gaming");
			uiMsg.text = gameState.ToString();
		}

		void Modify_Gaming()
		{
			if (Input.anyKeyDown)
			{
				In_Result();
				return;
			}

			Debug.Log("Modify_Gaming");
			//............
		}
		#endregion //gaming end...


		#region Result...
		void In_Result()
		{
			//0. state change.
			gameState = eGameState.Result;

			//1. resoure read. tile message display...
			Debug.Log("In_Result");
			uiMsg.text = gameState.ToString();
		}

		void Modify_Result()
		{
			if (Input.anyKeyDown)
			{
				if (Input.GetMouseButtonDown(0))
				{
					In_Ready();
				}
				else
				{
					In_Round();
				}
				return;
			}

			Debug.Log("Modify_Result");
			//............
		}
		#endregion //gaming end...



		// Update is called once per frame
		void Update()
		{
			switch (gameState)
			{
				case eGameState.Ready:
					Modify_Ready();
					break;
				case eGameState.Round:
					Modify_Round();
					break;
				case eGameState.Gaming:
					Modify_Gaming();
					break;
				case eGameState.Result:
					Modify_Result();
					break;
			}
		}
	}
}
