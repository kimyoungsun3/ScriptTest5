using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeletegatePopupPopup{
	public class GameManager : MonoBehaviour {
		
		IEnumerator Start () {
			bool[] result = new bool[3];
			//--------------------------------
			Debug.Log ("Step 1 popup ");
			bool _wait = true;
			Ui_Popup.ins.InitPopup (
				delegate(bool _b){
					Debug.Log("Popup => " + _b);
					_wait = false;
					result[0] = _b;
				}
			);

			while (_wait)
				yield return null;
			
			//--------------------------------
			Debug.Log ("Step 2 popup ");
			_wait = true;_wait = true;
			Ui_Popup2.ins.InitPopup (
				delegate(bool _b){
					Debug.Log("Popup => " + _b);
					_wait = false;
					result[1] = _b;
				}
			);

			while (_wait)
				yield return null;

			//--------------------------------
			Debug.Log ("Step 3 popup ");
			_wait = true;_wait = true;
			Ui_Popup3.ins.InitPopup (
				delegate(bool _b){
					Debug.Log("Popup => " + _b);
					_wait = false;
					result[2] = _b;
				}
			);

			while (_wait)
				yield return null;

			//--------------------------------
			for (int i = 0, iMax = result.Length; i < iMax; i++) {				
				Debug.Log (string.Format("result[{0}]={1}", i, result[i]));
			}
		}



	}
}
