using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AddUnitTest
{
	[System.Serializable]
	public class UnitData
	{
		//public int step;
		public Sprite sprite;
	}

	public class Spawner : MonoBehaviour
	{
		public static Spawner ins { get; private set; }


		[SerializeField] float NEXT_TIME = 0.2f;
		float nextTime;
		public List<UnitData> listUnitDic	= new List<UnitData>();
		public List<UnitItem> listUnitData	= new List<UnitItem>();
		[SerializeField] UnitItem prefab;
		[SerializeField] Transform minT, maxT;
		Vector3 min, max;

		void Awake()
		{
			if (ins != null)
			{
				Destroy(gameObject);
				return;
			}

			ins = this;
			min = minT.position;
			max = maxT.position;
		}

		void Update()
		{
			#if UNITY_EDITOR
				Debug.DrawLine(min, max);
			#endif

			if (Time.time > nextTime)
			{
				nextTime = Time.time + NEXT_TIME;
				float _x = Random.Range(min.x, max.x);
				float _y = Random.Range(min.y, max.y);
				UnitItem _scp = Instantiate(prefab, new Vector3(_x, _y, 0), Quaternion.identity) as UnitItem;
				_scp.gameObject.SetActive(true);
				_scp.Init(0);

				listUnitData.Add(_scp);
			}
		}
	}

}