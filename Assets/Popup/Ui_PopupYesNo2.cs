using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Popup
{
	public class Ui_PopupYesNo2 : MonoBehaviour {
		public static Ui_PopupYesNo2 instance;
		public GameObject body;
		System.Action<EnumSelect> callback;

		private void Awake()
		{
			Debug.Log(gameObject.scene);
			if (instance != null)
			{
				Destroy(gameObject);
				return;
			}
			instance = this;
			body.SetActive(false);
		}

		public void ShowPopup(System.Action<EnumSelect> _cb)
		{
			callback = _cb;
			body.SetActive(true);
		}

		public void InvokeYes()
		{
			if(callback != null)
			{
				callback(EnumSelect.Yes);
				callback = null;
			}
			body.SetActive(false);
		}

		public void InvokeNo()
		{
			if (callback != null)
			{
				callback(EnumSelect.No);
				callback = null;
			}
			body.SetActive(false);
		}
	}
}