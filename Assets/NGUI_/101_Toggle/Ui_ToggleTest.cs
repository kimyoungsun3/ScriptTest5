using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGUI_ToggleTest
{
	public class Ui_ToggleTest : MonoBehaviour
	{
		Transform body;
		Transform trans;

		private void Start()
		{
			trans = transform;
			if(body == null)
				body = trans.GetChild(0);
		}

		public void InvokeClose()
		{
			body.gameObject.SetActive(!body.gameObject.activeSelf);
		}
	}
}