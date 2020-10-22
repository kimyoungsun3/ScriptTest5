using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FindOfView
{
	[System.Serializable]
	public class SpawnData
	{
		public int total;
		public float interval;
	}



	public class SpawnerManager : MonoBehaviour
	{
		public List<SpawnData> list = new List<SpawnData>();


		void Update()
		{

		}
	}
}