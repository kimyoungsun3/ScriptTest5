using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PopupDouble{
	public delegate void VOID_FUN_VOID();
	public class GameManager : MonoBehaviour {
		public List<GameObject> list = new List<GameObject> ();


		void Start () {
			for (int i = 0, iMax = list.Count; i < iMax; i++)
				list [i].SetActive (false);
			list [0].SetActive (true);
			StartCoroutine (Co_PopupDistribute ());
		}


		IEnumerator Co_PopupDistribute(){

			bool _bWait = true;
			UiPopup _scp = list [0].GetComponent<UiPopup> ();
			_scp.InvokeCall (delegate() {
				_bWait = false;
				list[1].SetActive(true);
				Debug.Log(" > first OK");
			});
			while (_bWait) {
				yield return null;
			}

			_bWait = true;
			_scp = list [1].GetComponent<UiPopup> ();
			_scp.InvokeCall (delegate() {
				_bWait = false;
				list[2].SetActive(true);
				Debug.Log(" > Second OK");
			});
			while (_bWait) {
				yield return null;
			}


			_bWait = true;
			_scp = list [2].GetComponent<UiPopup> ();
			_scp.InvokeCall (delegate() {
				_bWait = false;
				//list[2].SetActive(true);
				Debug.Log(" > third OK");
			});
			while (_bWait) {
				yield return null;
			}
		}

	}
}