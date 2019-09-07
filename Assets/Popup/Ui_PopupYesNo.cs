using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Popup
{
	public class Ui_PopupYesNo : MonoBehaviour
	{
		public static Ui_PopupYesNo instance;
		private System.Action<EnumSelect> onSelected;
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

		public void Select(System.Action<EnumSelect> _onSelected)
		{
			onSelected = _onSelected;
			body.SetActive(true);
		}

		public void InvokeSelectYes()
		{
			if (onSelected != null)
			{
				onSelected(EnumSelect.Yes);
				body.SetActive(false);
			}
		}

		public void InvokeSelectNo()
		{
			if (onSelected != null)
			{
				onSelected(EnumSelect.No);
				body.SetActive(false);
			}
		}
	}
}
