using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XMLTest01
{
	public enum eMonsterType { GroupA, GroupB};
	public class MonsterData
	{
		public int itemcode;
		public string name;
		public string filedata;
		public GameObject goFileData;
		public eMonsterType type;
		public float health;
		public float attacktime;
		public float attackpower;
		public float attackspeed;
		public float waittime;
		public float speedmove;
		public float speedchase;
		public float speedturn;
		public float radius;
		public float radiusattack;
		public float radiustorelease;

		public void ReadFileData()
		{
			goFileData = Resources.Load<GameObject>("prefab/" + filedata);
			Debug.Log(goFileData);
		}

		public override string ToString()
		{
			return itemcode
				+ " name:" + name
				+ " :" + type
				+ " :" + health
				+ " :" + attacktime
				+ " :" + attackpower
				+ " :" + attackspeed
				+ " :" + waittime
				+ " :" + speedmove
				+ " :" + speedchase
				+ " :" + speedturn
				+ " :" + radius
				+ " :" + radiusattack
				+ " :" + radiustorelease;
		}
	}
}