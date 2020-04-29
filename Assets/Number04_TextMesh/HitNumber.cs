using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Number02_TextMesh
{
	public class HitNumber : MonoBehaviour
	{
		static int siblingIndex;
		[SerializeField] Text text;		
		[SerializeField] AnimationCurve curve;
		[SerializeField] AnimationCurve curveAlpha;
		[SerializeField] float duration = 1f;
		[SerializeField] float durationAlpah = 1f;
		RectTransform rectTrans;
		GameObject go;
		[SerializeField] Vector3 offset = new Vector3(0, 10, 0);
		[SerializeField] Vector2 randArea = new Vector2(10f, 2f);
		Color color;
		Color color2;
		Outline outline;
		public void SetData(Vector3 _screenPos, int _damage)
		{
			if (rectTrans == null)
			{
				go			= gameObject;
				rectTrans	= (RectTransform)transform;

				color		= text.color;
				outline = GetComponent<Outline>();
				color2	= outline.effectColor;
			}

			StartCoroutine(Co_MoveUp(_screenPos, _damage));
		}

		IEnumerator Co_MoveUp(Vector3 _screenPos, int _damage)
		{
			transform.SetSiblingIndex(siblingIndex++);
			//go.SetActive(false);
			//rectTrans.position = new Vector3(_screenPos.x * Screen.width, _screenPos.y * Screen.height, 0);
			_screenPos.z = 0;
			text.color = color;
			outline.effectColor = color2;


			rectTrans.position = _screenPos + new Vector3(Random.Range(-randArea.x, randArea.x), Random.Range(-randArea.y, randArea.y), 0);
			text.text		= _damage.ToString();

			float _speed	= 1f / duration;
			float _percent	= 0f;
			float _interval = 0;
			Vector3 _p1 = rectTrans.localPosition;
			Vector3 _p2 = rectTrans.localPosition + offset;

			while (_percent <= 1f)
			{
				_percent += _speed * Time.deltaTime;
				_interval = curve.Evaluate(_percent);
				rectTrans.localPosition = Vector3.Lerp(_p1, _p2, _interval);
				yield return null;
			}

			_speed = 1f / durationAlpah;
			_percent = 0;
			Color _c11 = color;
			Color _c12 = color;
			_c12.a = 0;
			Color _c21 = color2;
			Color _c22 = color2;
			_c22.a = 0;
			while (_percent <= 1f)
			{
				//Debug.Log(1);
				_percent += _speed * Time.deltaTime;
				_interval = curveAlpha.Evaluate(_percent);
				text.color			= Color.Lerp(_c11, _c12, _interval);
				outline.effectColor = Color.Lerp(_c21, _c22, _interval);
				yield return null;
			}

			//return pool
			go.SetActive(false);
		}
	}
}
