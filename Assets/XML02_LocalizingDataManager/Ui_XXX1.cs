using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LocalizingDataManagerTest
{
	public class Ui_XXX1 : MonoBehaviour
	{
		public eLanguageType typeLanguage;
		private void Awake()
		{
			LocalizingDataManager.Instance.SetLanguage(typeLanguage);
		}
	}
}