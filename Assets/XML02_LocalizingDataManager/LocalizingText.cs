using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LocalizingDataManagerTest
{
	[System.Serializable]
	public class LocalizeText
	{
		public string uniqueID;
		public UILabel label;
	}

	public class LocalizingText : MonoBehaviour
	{
		public bool isStart = false;
		[SerializeField] private LocalizeText[] localizeTexts;
		
		void Start()
		{
			if (Constant.DEBUG)
				Debug.Log(this + " Awake");
			LocalizingDataManager.Instance.SetLocalizeLabel(this, isStart);
		}

		public LocalizeText[] GetLocalizeTexts()
		{
			if (Constant.DEBUG) Debug.Log(this + " GetLocalizeTexts");
			return localizeTexts;
		}
	}
}