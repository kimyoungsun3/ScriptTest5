using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGUI_TweenTest
{
	public class Ui_TweenTest : MonoBehaviour
	{
		public void Invoke_BTN_Alpha(TweenAlpha _target)
		{
			GameObject _goTarget = _target.gameObject;
			if (_goTarget.activeSelf)
			{
				_goTarget.SetActive(false);
			}
			else
			{
				_goTarget.SetActive(true);
				_target.ResetToBeginning();
				_target.PlayForward();
				EventDelegate.Add(_target.onFinished, OnAlpahFinishedTrue);
			}
		}

		void OnAlpahFinishedTrue()
		{
			Debug.Log("true");
		}

		public void Invoke_BTN_AlphaScript(GameObject _goTarget)
		{
			if (_goTarget.activeSelf)
			{
				_goTarget.SetActive(false);
			}
			else
			{
				_goTarget.SetActive(true);
				TweenAlpha _t = TweenAlpha.Begin(_goTarget, 0.2f, 1f);
				_t.from = 0.0f;
				_t.to	= 1f;
				_t.ResetToBeginning();

				EventDelegate.Add(_t.onFinished, OnAlpahFinishedTrue);
			}
		}

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

		public void InvorkShowBox2(GameObject _go)
		{
			if (_go.activeSelf)
			{
				//on -> off
				_go.SetActive(false);
			}
			else
			{
				//off -> on and reset and play
				_go.SetActive(true);
				TweenScale _ts = _go.GetComponent<TweenScale>();
				_ts.ResetToBeginning();
				_ts.PlayForward(); //0.8 -> 1

				TweenAlpha _ta = _go.GetComponent<TweenAlpha>();
				_ta.ResetToBeginning();
				_ta.PlayForward();
			}
		}
	}
}
