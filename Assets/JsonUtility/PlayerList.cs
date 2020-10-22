using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _196_JsonUtility
{
	public class PlayerList : MonoBehaviour
	{
		public List<PlayerData> list_PlayerData = new List<PlayerData>();
		[TextArea(15,20)]public string jsonPlayerData;
		
		void Start()
		{
			jsonPlayerData = JsonHelper.ToJson(list_PlayerData.ToArray(), true);
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				jsonPlayerData = JsonHelper.ToJson(list_PlayerData.ToArray(), true);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				PlayerData[] _arr = JsonHelper.FromJson<PlayerData>(jsonPlayerData);
				list_PlayerData.Clear();
				list_PlayerData.AddRange(_arr) ;
			}
		}
	}
}