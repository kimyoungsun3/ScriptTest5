using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _ListSort
{
	public enum eSearchType { DistanceShort, HealthMany}
	public class Turret : MonoBehaviour
	{
		[SerializeField] eSearchType searchType;
		[SerializeField] eWayType wayType;
		[SerializeField] Bullet bulletPrefab;
		[SerializeField] float damage = 10f;
		[SerializeField] List<Transform> spawnPoints = new List<Transform>();
		Enemy enemy;
		[SerializeField] float SHOOT_TIME = 0.2f;
		float shootTime;
		int shootIndex;

		// Update is called once per frame
		void Update()
		{
			//if(enemy == null || enemy.gameObject.activeSelf == false)
			//{
			//	SearchEnemy();
			//}
			
			SearchEnemy();
			if(Time.time > shootTime && enemy && enemy.gameObject.activeSelf)
			{
				shootTime		= Time.time + SHOOT_TIME / spawnPoints.Count;
				Bullet _bullet	= Instantiate(bulletPrefab, spawnPoints[shootIndex].position, Quaternion.identity) as Bullet;
				_bullet.SetData(enemy, damage);
				shootIndex = (shootIndex + 1) % spawnPoints.Count;
			}
		}

		void SearchEnemy()
		{
			switch (searchType)
			{
				case eSearchType.DistanceShort:
					enemy = Spawner.ins.GetDistance(wayType);
					break;
				case eSearchType.HealthMany:
					enemy = Spawner.ins.GetHealth(wayType);
					break;
			}	
		}
	}
}