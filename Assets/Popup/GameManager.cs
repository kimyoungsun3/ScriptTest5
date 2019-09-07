using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Popup
{
	public enum EnumLanguage { None, Korea, English, Japan };
	public enum EnumSelect { None, Yes, No };
	public class GameManager : MonoBehaviour {


		void Start() {
			StartCoroutine("Co_Init");
		}

		IEnumerator Co_Init()
		{
			Debug.Log(" >> Co_Init");
			Debug.Log(" >> 1");
			yield return new WaitForSeconds(2f);

			Debug.Log(" >> 2");
			yield return StartCoroutine(Co_Init2());

			Debug.Log(" >> 3");
			bool _bWait = true;
			Ui_PopupLanguage.instance.Select((EnumLanguage _language) => {
				_bWait = false;
				Debug.Log(" >> 언어선택:" + _language);
			});
			while (_bWait) yield return null;

			Debug.Log(" >> 4");
			_bWait = true;
			Ui_PopupYesNo.instance.Select((EnumSelect _select) => {
				_bWait = false;
				Debug.Log(" >> YN선택:" + _select);
			});
			while (_bWait) yield return null;

		}

		IEnumerator Co_Init2()
		{
			Debug.Log(" >> Co_Init2");
			yield return new WaitForSeconds(2f);
		}

	}
}
