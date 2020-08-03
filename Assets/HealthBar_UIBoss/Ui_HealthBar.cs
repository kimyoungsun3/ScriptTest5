using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _HealthBar_UIBoss
{
	public class Ui_HealthBar : MonoBehaviour
	{
		#region singletone
		public static Ui_HealthBar ins;
		private void Awake()
		{
			ins = this;
		}
		#endregion

		[SerializeField, Range(0.1f, 1f)] float duration = 1f;
		[SerializeField, Range(0.5f, 2f)] float waitTime = 1f;
		WaitForSeconds wait;
		[SerializeField] Text title;
		//[SerializeField] Slider slider;
		[SerializeField] AnimationCurve curve;
		[SerializeField] Color colorBG, colorFG1, colorFG2;
		[SerializeField] Image bg, fg;

		public void SetInit(string _str)
		{
			title.text		= _str;
			bg.fillAmount	= 1f;
			fg.fillAmount	= 1f;
			//slider.value = 1f;
		}

		Coroutine coroutine;
		public void SetHit(float _value)
		{
			if (coroutine != null)
				StopCoroutine(coroutine);
			coroutine = StartCoroutine(Co_SetHit(_value));
		}

		IEnumerator Co_SetHit(float _value)
		{
			//1.차 쭉줄어드는 모양...
			float _speed = 1f / duration;
			float _percent = 0f;
			float _p0 = fg.fillAmount;
			float _p1 = _value;
			float _interval;
			while (_percent < 1f)
			{
				_percent	+= _speed * Time.deltaTime;
				_interval	= curve.Evaluate(_percent);
				fg.fillAmount = Mathf.Lerp(_p0, _p1, _interval);
				yield return null;
			}

			//2. 약간 기다렸다가...
			yield return new WaitForSeconds(waitTime);

			//3. 뒤에것도 쭉줄어듬...
			_percent = 0f;
			_p0 = bg.fillAmount;
			while (_percent < 1f)
			{
				_percent += _speed * Time.deltaTime;
				_interval = curve.Evaluate(_percent);
				bg.fillAmount = Mathf.Lerp(_p0, _p1, _interval);
				yield return null;
			}
		}
	}
}
