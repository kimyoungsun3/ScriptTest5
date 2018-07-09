using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeletegatePopupPopup{
	public class Ui_Popup : MonoBehaviour {
		public static Ui_Popup ins;
		public GameObject neckPoint;
		System.Action<bool> callbackAccept;

		void Awake(){
			ins = this;
			neckPoint.SetActive (false);
		}

		public void InitPopup(System.Action<bool> _callback){
			neckPoint.SetActive (true);
			callbackAccept = _callback;
			//... Data Setting....
		}

		//----------------------------------------
		public void InvokeOk(){
			Result (true);
		}

		public void InvokeCancel(){
			Result (false);
		}

		void Result(bool _b){
			if (callbackAccept != null) {
				callbackAccept (_b);
				callbackAccept = null;
			}
			neckPoint.SetActive (false);
		}
	}

}