using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGUI_TweenTest
{
	public class Ui_Targets : MonoBehaviour
	{

		public void InvokeClose(GameObject _go)
		{
			_go.SetActive(false);
		}
	}
}
