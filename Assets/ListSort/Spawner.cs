using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _ListSort
{
	public class Spawner : MonoBehaviour
	{
		#region singletone
		public static Spawner ins { get; private set; }
		private void Awake()
		{
			ins = this;
			Application.runInBackground = true;
			Screen.sleepTimeout = SleepTimeout.NeverSleep;
		}
		#endregion

		[SerializeField] Enemy enemyPrefab;
		[SerializeField] float NEXTF_TIME = 1f;
		public List<Enemy> list = new List<Enemy>();
		float nextTime, sortTime;
		int count;
		bool bSort;
		public List<Enemy> listDistance = new List<Enemy>();
		public List<Enemy> listHealth = new List<Enemy>();

		// Update is called once per frame
		void Update()
		{
			if(Time.time > nextTime)// && count < 10)
			{
				nextTime = Time.time + NEXTF_TIME;

				eWayType _type = (count++ % 2 == 0) ? eWayType.Down : eWayType.Up;
				Enemy _enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity) as Enemy;
				_enemy.SetData(100 + count * 10, _type);
				_enemy.name += count.ToString() + _type.ToString();
				_enemy.transform.SetParent(transform);

				list.Add(_enemy);
				listDistance.Add(_enemy);
				listHealth.Add(_enemy);
				bSort = true;
			}

			if (Time.time > sortTime && list.Count > 0)
			{
				sortTime = Time.time + 1f/20f;
				SortList();
			}				
		}

		public void RemoveEnemy(Enemy _enemy)
		{
			list.Remove(_enemy);
			listDistance.Remove(_enemy);
			listHealth.Remove(_enemy);

			//SortList();
			bSort = true;
		}

		public void SortList()
		{
			bSort = false;
			//오름차순
			listDistance.Sort((_x1, _x2) => _x1.distance.CompareTo(_x2.distance));//오름차순.
			//listDistance.Sort((_x1, _x2) => _x2.distance.CompareTo(_x1.distance));//내림차순.
			//listHealth.Sort((_x1, _x2) => _x1.distance.CompareTo(_x2.distance));//오름차순.
			listHealth.Sort((_x1, _x2) => _x2.health.CompareTo(_x1.health));//내림차순.
		}

		public Enemy GetDistance(eWayType _type)
		{
			Enemy _enemy = null;
			Point _point;
			for(int i = 0, imax = listDistance.Count; i< imax; i++)
			{
				_point = listDistance[i].point;
				if (_point.type == _type || _point.type == eWayType.Common)
				{
					_enemy = listDistance[i];
					break;
				}
			}
			return _enemy;
		}

		public Enemy GetHealth(eWayType _type)
		{
			Enemy _enemy = null;
			Point _point;
			for (int i = 0, imax = listHealth.Count; i < imax; i++)
			{
				_point = listHealth[i].point;
				if (_point.type == _type || _point.type == eWayType.Common)
				{
					_enemy = listHealth[i];
					break;
				}
			}
			return _enemy;
		}
	}
}