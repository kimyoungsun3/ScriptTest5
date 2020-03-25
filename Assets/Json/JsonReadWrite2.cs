using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JsonTest
{

	public class JsonReadWrite2 : MonoBehaviour
	{
		[SerializeField] UILabel uiDisplay;
		public UserData userData, userData2;
		public JSONObject jsonObject;
		public string strData;


		[ContextMenu("ToJson JSONObject")]
		void ToJson()
		{
			jsonObject = new JSONObject();
			jsonObject.AddField("name", userData.name);
			jsonObject.AddField("age", userData.age);
			jsonObject.AddField("female", userData.female);
			//jsonObject.AddField("items", userData.items);

			uiDisplay.text = jsonObject.ToString();
		}


		[ContextMenu("FromJson(class)")]
		void FromJson()
		{

		}

	}
}
