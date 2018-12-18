using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundManager7{
	public class PlayTTT : MonoBehaviour {
		
		void Update () {
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				SoundManager.ins.Play ("BGM", true);
			}	
			else if (Input.GetKeyDown (KeyCode.Alpha2)) {
				SoundManager.ins.Stop ("EngineIdle");
				SoundManager.ins.Play ("EngineDriving", true);
			}	
			else if (Input.GetKeyDown (KeyCode.Alpha3)) {
				SoundManager.ins.Stop ("EngineDriving");
				SoundManager.ins.Play ("EngineIdle", true);
			}	
			else if (Input.GetKeyDown (KeyCode.Alpha4)) {
				SoundManager.ins.Play ("ShellExplosion", false);
			}	
			else if (Input.GetKeyDown (KeyCode.Alpha5)) {
				SoundManager.ins.Play ("ShotCharging", false);
			}	
			else if (Input.GetKeyDown (KeyCode.Alpha6)) {
				SoundManager.ins.Play ("TankExplosion", false);
			}					
		}
	}
}
