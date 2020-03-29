using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XMLTest01
{
	public class GameData : MonoBehaviour
	{
		#region sigletone
		public static GameData ins;
		private void Awake()
		{
			ins = this;
			LoadData();
		}
		#endregion

		//정의부분....
		private Dictionary<int, MonsterData> dic_MonsterData = new Dictionary<int, MonsterData>();

		//읽기 부분...
		public void LoadData()
		{
			Debug.Log(33 + ":" + LoaderXML.ins);
			Debug.Log(44 + ":" + LoaderXML.ins);
			LoaderXML.ins.LoadMonster(dic_MonsterData, "monster_data2");
		}

		//해당 부분 찾기...
		public MonsterData GetMonsterData(int _itemcode)
		{
			if (dic_MonsterData.ContainsKey(_itemcode))
			{
				return dic_MonsterData[_itemcode];
			}
			return null;
		}
	}
}
