using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager4{
	public class GameManager : FSM<GAME_STATE> {
		
		#region Variable Zone
		private static GameManager ins_;
		public static GameManager ins{
			get{	return ins_;	}
			set{ 	ins_ = value; 	}
		}
		#endregion

		#region 게임 Instance 클래스...
		//PlayerPlatformerController player;
		//EnemySpawner enemySpawner;
		//public bool bPause;

		[Header("개발링크")]
		public Ui_XXXX 				uiXXXX;
		//public Ui_Result 			uiResult;
		//public VirtualJoystick	uiJoystick;
		//public Ui_RightButton		uiRightButton;
		//public Ui_Crosshair 		uiCrosshair;
		#endregion

		[Space]
		#region 게임 Variable
		float waitTime;
		float GAME_END_WAITTIME = 3f;
		#endregion


		void Awake(){
			ins = this;
			SetEnvironment ();		
		}

		void SetEnvironment(){
			//에디터 모드에서 실행.
			#if UNITY_EDITOR
			Application.runInBackground 	= true;//editor mode back ground is run..
			//Cursor.visible 				= false;
			#endif

			//아직미검증....
			//Debug.Log ("### -> frame -> 발열해결 ->속제한해제된상태...");
			//V sync makes the frame display update wait for the screen refresh update, 
			//in other words it ties your frame rate to your monitors refresh rate(60htz, 100htz etc).
			//If you set it to 0 then it ignores your monitor refresh and outputs the frames as fast as possible.
			//If you set it to 1 then it will output one frame update for every screen update.
			//If you set it to 2 it will output one frame update every second screen update.
			//This is often used for trying to stop screen tearing issues by keeping the two in sync.
			//-1   : 끊어짐 발생
			//0    : 끊어짐 발생
			//1    : 정상...
			//2    : 끊어짐 발생
			//3    : 끊어짐이 심해짐...
			//4    : 더끊어짐이 심해짐...
			//QualitySettings.vSyncCount 	= 1;
			Application.targetFrameRate = 55;	

			//55 -> 발열... 
		}

		void Start () {
			AddState(GAME_STATE.Ready, 	pInReady, 	ModifyReady, 	null);
			AddState(GAME_STATE.Gaming, pInGaming, 	ModifyGaming, 	null);
			AddState(GAME_STATE.Result, pInResult, 	ModifyResult, 	null);

			MoveState(GAME_STATE.Ready);
		}

		//-----------------------------------------------------------
		//--- Ready ---
		//-----------------------------------------------------------
		public void pInReady(){
			uiXXXX.SetActive2 (true);
			uiXXXX.SetMessage ("Ready");

			//SoundManager.ins.Init ();
			//SoundManager.ins.Play ("BGM", true);
		}

		void ModifyReady(){
			if (Input.anyKeyDown) {
				MoveState(GAME_STATE.Gaming);
				return;
			}
		}

		//-----------------------------------------------------------
		//--- Gaming ---
		//-----------------------------------------------------------
		public void pInGaming(){
			uiXXXX.SetActive2 (true);
			uiXXXX.SetMessage ("Gaming");

			//uiSceneInfo.SetActive2 (false);
			//uiResult.SetActive2 (false);

			//Sound plays Main Theme.
			//SoundManager.ins.Play ("Main theme", true);

			//user info initiaize
			//player.InitFirst ();
			//player.EnableController();

			//Spawner Setting...
			//EnemySpawner.ins.EnableControl (0, player.transform);
		}

		void ModifyGaming(){
			if (Input.anyKeyDown) {
				MoveState(GAME_STATE.Result);
				return;
			}
		}

		//-----------------------------------------------------------
		//--- Result ---
		//-----------------------------------------------------------
		void pInResult(){
			//Spawn Wave -> pInGame...
			uiXXXX.SetActive2 (true);
			uiXXXX.SetMessage ("Game Result");
		}

		void ModifyResult(){
			if (Input.anyKeyDown) {
				MoveState(GAME_STATE.Ready);
				return;
			}
		}

	}
}