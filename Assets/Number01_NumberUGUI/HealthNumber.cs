using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Number01_NumberUGUI
{
	public class HealthNumber : MonoBehaviour
	{
		RectTransform rectTrans;
		GameObject go;
		Text text;
		public void SetData(int _health)
		{
			if (rectTrans == null)
			{
				text = GetComponent<Text>();
				go = gameObject;
				rectTrans = (RectTransform)transform;				
			}

			DisplayHealth(_health);
		}

		public void SetMove(Vector3 _pos)
		{
			rectTrans.position = _pos;
		}

		public void DisplayHealth(int _health)
		{
			text.text = _health.ToString();
		}

	}
}