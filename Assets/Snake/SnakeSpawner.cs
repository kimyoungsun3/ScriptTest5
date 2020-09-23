using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
	public class SnakeSpawner : MonoBehaviour
	{
		#region singletone
		public static SnakeSpawner ins;
		private void Awake()
		{
			ins = this;
		}
		#endregion

		[Range(0.01f, 2f)] public float NEXT_TIME = 0.5f;
		float nextTime;
		public Transform prefab;
		public int maxCount = 10;
		public List<Transform> list = new List<Transform>();


		private void Update()
		{
			if (Time.time > nextTime && list.Count < maxCount)
			{
				nextTime = Time.time + NEXT_TIME;

				Vector3 _pos = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
				Transform _t = Instantiate(prefab, _pos, Quaternion.identity) as Transform;
				_t.SetParent(transform);

				list.Add(_t);
			}
		}

		public void RemoveItem(Transform _t)
		{
			list.Remove(_t);
		}
	}
}
