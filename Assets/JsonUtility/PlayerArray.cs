using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _196_JsonUtility
{
	public class PlayerArray : MonoBehaviour
	{
		public PlayerData[] arrPlayerData;
		[TextArea(15,20)]public string jsonPlayerData;
		
		void Start()
		{
			jsonPlayerData = JsonHelper.ToJson(arrPlayerData, true);
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				jsonPlayerData = JsonHelper.ToJson(arrPlayerData, true);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				arrPlayerData = JsonHelper.FromJson<PlayerData>(jsonPlayerData);
			}
		}
	}
}