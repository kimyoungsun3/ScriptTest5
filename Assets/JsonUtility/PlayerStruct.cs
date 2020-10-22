using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _196_JsonUtility
{
	[System.Serializable]
	public class PlayerDataSturct
	{
		public string sid;
		public string nickname;		
		public float health;
		[SerializeField] int gamecost;
	}

	public class PlayerStruct : MonoBehaviour
	{
		public PlayerDataSturct playerData;
		[TextArea(3,5)]public string jsonPlayerData;
		
		void Start()
		{
			jsonPlayerData = JsonUtility.ToJson(playerData, true);
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				jsonPlayerData = JsonUtility.ToJson(playerData, true);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				playerData = JsonUtility.FromJson<PlayerDataSturct>(jsonPlayerData);
			}
		}
	}
}