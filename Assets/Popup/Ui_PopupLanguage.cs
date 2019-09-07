using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Popup
{
	public class Ui_PopupLanguage : MonoBehaviour
	{
		public static Ui_PopupLanguage instance;
		private System.Action<EnumLanguage> onSelected;
		public GameObject body;

		private void Awake()
		{
			if (instance != null)
			{
				Destroy(gameObject);
				return;
			}
			instance = this;
			body.SetActive(false);
		}

		public void Select(System.Action<EnumLanguage> _onSelected)
		{
			onSelected = _onSelected;
			body.SetActive(true);
		}

		public void InvokeSelectKorea()
		{
			if(onSelected != null)
			{
				onSelected(EnumLanguage.Korea);
				body.SetActive(false);
			}
		}

		public void InvokeSelectEnglish()
		{
			if (onSelected != null)
			{
				onSelected(EnumLanguage.English);
				body.SetActive(false);
			}
		}

		public void InvokeSelectJapan()
		{
			if (onSelected != null)
			{
				onSelected(EnumLanguage.Japan);
				body.SetActive(false);
			}
		}
	}
}