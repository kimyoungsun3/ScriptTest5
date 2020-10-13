using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoolManager_Class_destructor1
{
	[System.Serializable]
	public class Packdata
	{
		public static int indexSequence;
		public int index = -1;
		public int code;
		public int error;
		public int callCount;
		public Packdata() {
			index = indexSequence++;
		}

		public void PlusCount()
		{
			callCount++;
		}

		~Packdata()
		{
			Debug.Log(index + " >> return");
			ObjectPool<Packdata>.Enqueue(this);
		}
	}

	public class ObjectPoolTest : MonoBehaviour
	{
		public List<Packdata> list = new List<Packdata>();
		
		void Start()
		{
			ObjectPool<Packdata>.Initialize(100);
		}

		Packdata packSample;
		void Update()
		{
			if (Random.Range(0, 2) == 0)
			{
				Packdata _packet = ObjectPool<Packdata>.Dequeue();
				_packet.PlusCount();
				list.Add(_packet);
			}
			else if (list.Count > 0)
			{
				//회수 >> GC (정확한 시점이 없어서) >> 회수가 임의의 지점에 회수
				//재사용할려는데 아직 회수가 없어서 생성을 해버림.....
				//ObjectPool<Packdata>.Enqueue(list[0]);
				list.RemoveAt(0);
			}

			Debug.Log(list.Count + ":" + ObjectPool<Packdata>.queue.Count);
		}
	}
}