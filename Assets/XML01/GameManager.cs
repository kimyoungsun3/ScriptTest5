using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XMLTest01
{
	public class GameManager : MonoBehaviour
	{

		public int itemcode = 10001;
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				Debug.Log(GameData.ins.GetMonsterData(itemcode));
			}
		}

	}
}
