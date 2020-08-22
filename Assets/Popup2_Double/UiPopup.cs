using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PopupDouble{
	public class UiPopup : MonoBehaviour {

		VOID_FUN_VOID onFinished;

		public void InvokeCall(VOID_FUN_VOID _on){
			onFinished = _on;
		}

		void OnMouseDown(){
			if (onFinished != null) {
				onFinished ();
				onFinished = null;
				gameObject.SetActive (false);
			}
		}
	}
}
