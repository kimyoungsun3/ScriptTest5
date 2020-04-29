using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SoundManager6{
	public class UiTest : MonoBehaviour {

		public void InvokePlaySoundBGM(){			
			SoundManager.ins.Play ("BGM", true);
		}

		public void InvokePlaySound(string _str){
			SoundManager.ins.Play (_str, false);
		}
	}
}
