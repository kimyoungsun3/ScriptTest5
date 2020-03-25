using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGUI_TweenTest
{
	public class Ui_TweenPopupCommon : MonoBehaviour
	{

		public void InvokePupup(GameObject _go)
		{
			if (_go.activeSelf)
			{
				_go.SetActive(false);
			}
			else
			{
				_go.SetActive(true);

				TweenScale _ts = _go.GetComponent<TweenScale>();
				_ts.ResetToBeginning();
				_ts.PlayForward();

				TweenAlpha _ta = _go.GetComponent<TweenAlpha>();
				_ta.ResetToBeginning();
				_ta.PlayForward();
			}
		}

		public void InvokeClose(GameObject _go)
		{
			_go.SetActive(false);
		}
	}
}
