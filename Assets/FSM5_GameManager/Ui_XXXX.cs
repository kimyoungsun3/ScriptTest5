using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FSM5{
	public class Ui_XXXX : MonoBehaviour {
		public static Ui_XXXX ins { get; private set; }
		public UILabel label;

		void Awake(){
			ins = this;
			gameObject.SetActive (false);
		}

		public void SetActive2(bool _b = false){
			gameObject.SetActive (_b);
		}

		public void SetMessage(string _msg){
			label.text = _msg;
		}
	}
}