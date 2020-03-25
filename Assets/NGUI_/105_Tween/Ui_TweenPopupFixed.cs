using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGUI_TweenTest
{
	public class Ui_TweenPopupFixed : MonoBehaviour
	{

		[SerializeField] GameObject goPopupShow1;
		public void InvokePupup1()
		{
			GameObject _go = goPopupShow1;
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

		public void InvokeClose1()
		{
			goPopupShow1.SetActive(false);
		}

		//----------------------------------------------
		[SerializeField] GameObject goPopupShow2;
		public void InvokePupup2()
		{
			GameObject _go = goPopupShow2;
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

		public void InvokeClose2()
		{
			goPopupShow2.SetActive(false);
		}
	}
}
