using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UGUI_ButtonMask
{
	public class ButtonMask2 : MonoBehaviour
	{
		[SerializeField] RectTransform p1, p2;
		[Range(0.5f,  2f)] [SerializeField] float duration			= 1.2f;
		[Range(0.1f, 10f)] [SerializeField] float pauseDuration		= 0.5f;
		[SerializeField]RectTransform target;
		bool bCoroutine;

		private void OnEnable()
		{
			Mask _mask = GetComponent<Mask>();
			if(_mask != null)_mask.enabled = true;
			p1.gameObject.SetActive(false);
			p2.gameObject.SetActive(false);

			bCoroutine = true;
			StartCoroutine(Co_ButtonMask());
		}

		private void OnDisable()
		{
			bCoroutine = false;
		}

		[SerializeField] AnimationCurve curve;
		IEnumerator Co_ButtonMask()
		{
			float _speed = 1f / duration;
			float _percent;
			Vector3 _p1 = p1.position;
			Vector3 _p2 = p2.position;
			float _nextTime;
			bool _bPauseToggle = true;


			while (bCoroutine)
			{
				target.position = _p1;
				_percent = 0;
				_speed = 1f / duration;
				while (_percent <= 1f)
				{
					_percent += _speed * Time.deltaTime;
					target.position = Vector3.Lerp(_p1, _p2, curve.Evaluate(_percent));
					yield return null;
				}

				_bPauseToggle = !_bPauseToggle;
				if (_bPauseToggle) continue;
				_nextTime = Time.time + pauseDuration;
				while (Time.time < _nextTime) yield return null;
			}
		}

#if UNITY_EDITOR
		[Range(0f, 1f)] [SerializeField] float percent = 0f;
		private void OnDrawGizmos()
		{
			if (target == null) return;
			if(!Application.isPlaying)
				target.position = Vector3.Lerp(p1.position, p2.position, percent);

		}
#endif
	}

}