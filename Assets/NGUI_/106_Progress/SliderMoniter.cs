using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGUI_UIProgress
{
	public class SliderMoniter : MonoBehaviour
	{
		UISlider slider;

		// Use this for initialization
		void Awake()
		{
			slider = GetComponent<UISlider>();
			EventDelegate.Add(slider.onChange, OnChange);
			slider.onDragFinished += OnDragFinished;
		}

		private void OnChange()
		{
			Debug.Log("OnChange:" + slider.value);
		}

		void OnDragFinished()
		{
			Debug.Log("OnDragFinished:" + slider.value);
		}
	}
}
