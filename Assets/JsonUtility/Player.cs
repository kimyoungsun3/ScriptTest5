using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _196_JsonUtility
{
	[System.Serializable]
	public class SkillInfo
	{
		public int skillcode;
		public int point;
		public SkillInfo(int _skillcode, int _point)
		{
			skillcode	= _skillcode;
			point		= _point;
		}
	}

	[System.Serializable]
	public struct Item
	{
		public int itemcode;
		public int count;
		public Item(int _itemcode, int _count)
		{
			itemcode = _itemcode;
			count = _count;
		}
	}

	[System.Serializable]
	public class PlayerData
	{
		public string sid;
		public string nickname;		
		public float health;
		[SerializeField] int gamecost = 777;

		public Vector3 position;
		public Quaternion rotation;
		public int[] arrayInt			= new int[] { 1, 2, 3 };
		public Item[] arrayItems		= new Item[] { new Item(10001, 1), new Item(10002, 2) };
		public SkillInfo[] arraySkillInfo= new SkillInfo[] { new SkillInfo(20001, 1), new SkillInfo(20002, 2) };
	}

	public class Player : MonoBehaviour
	{
		public PlayerData playerData;
		[TextArea(10,15)]public string jsonPlayerData;
		public PlayerData playerData2;

		void Start()
		{
			jsonPlayerData	= JsonUtility.ToJson(playerData, true);
			playerData2		= JsonUtility.FromJson<PlayerData>(jsonPlayerData);
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				jsonPlayerData = JsonUtility.ToJson(playerData, true);
			}			
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				playerData2 = JsonUtility.FromJson<PlayerData>(jsonPlayerData);
			}
		}
	}
}