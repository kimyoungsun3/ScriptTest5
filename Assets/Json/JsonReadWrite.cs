using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JsonTest
{


	public class JsonReadWrite : MonoBehaviour
	{
		[SerializeField] UILabel uiDisplay;
		public UserData userData, userData2;
		public string strUserData;


		[ContextMenu(".ToJson(class)")]
		void ToJson()
		{
			strUserData = JsonUtility.ToJson(userData, true);
			uiDisplay.text = strUserData;
		}


		[ContextMenu(".FromJson(class)")]
		void FromJson()
		{
			userData2 = JsonUtility.FromJson<UserData>(strUserData);
		}



	}
}
