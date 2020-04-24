using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Joystick_UGUI2
{
	public class ClickAnimation : MonoBehaviour
	{
		private void Start()
		{
			if (image != null)
				image.gameObject.SetActive(false);
		}
		public void Invoke_Click()
		{
			if (image != null && !image.gameObject.activeSelf)
					StartCoroutine(Co_Action());
		}

		[SerializeField] Image image;
		[SerializeField] float duration = 0.35f;
		IEnumerator Co_Action()
		{
			image.gameObject.SetActive(true);
			image.rectTransform.localScale = Vector3.one;
			image.color = Color.white;

			Color _c1 = image.color;
			Color _c2 = image.color;
			_c2.a = 0f;
			float _speed = 1f / duration;
			float _percent = 0;
			Vector3 _p1 = Vector3.one;
			Vector3 _p2 = Vector3.one * 2f;

			Debug.Log(1);
			while (_percent <= 1f)
			{
				Debug.Log(2);
				_percent += _speed * Time.deltaTime;
				image.rectTransform.localScale = Vector3.Lerp(_p1, _p2, _percent);
				image.color = Color.Lerp(_c1, _c2, _percent);
				yield return null;
			}
			image.gameObject.SetActive(false);
		}
	}

}