using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM6;

namespace Step99
{
	public class Spawner : MonoBehaviour
	{
		public int count = 50;
		public float radius = 10f;
		public Enemy enemyA, enemyB;
		public List<Enemy> listA = new List<Enemy>();
		public List<Enemy> listB = new List<Enemy>();

		// Update is called once per frame
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				StartCoroutine(Co_SpanwerObject(enemyA, listA));
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				StartCoroutine(Co_SpanwerObject(enemyB, listB));
			}
			else if (Input.GetMouseButtonDown(0) && listA.Count <= 300)
			{
				StartCoroutine(Co_SpanwerObject(enemyA, listA));
				StartCoroutine(Co_SpanwerObject(enemyB, listB));
			}
		}

		IEnumerator Co_SpanwerObject(Enemy _enemy, List<Enemy> _list)
		{
			Vector3 _pos = Vector3.zero;
			Quaternion _rot = Quaternion.identity;
			Enemy _scp;
			for(int i = 0; i < count; i++)
			{
				_pos.Set(Random.Range(-radius, +radius), 0, Random.Range(-radius, +radius));
				_scp = Instantiate(_enemy, _pos, _rot) as Enemy;
				_list.Add(_scp);
				yield return null;
			}
		}
	}
}
