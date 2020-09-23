using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoolManager_Class
{

	[System.Serializable]
	public class Packdata
	{
		public static int indexSequence;
		public int index;
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
	}

	public class ObjectPoolTest : MonoBehaviour
	{
		public List<Packdata> list = new List<Packdata>();

		void Start()
		{
			ObjectPool<Packdata>.Initialize(100);
		}

		// Update is called once per frame
		void Update()
		{
			//if (Input.GetKey(KeyCode.Alpha1))
			//{
			//	list.Add(ObjectPool<Packdata>.Dequeue());
			//}
			//else if (Input.GetKey(KeyCode.Alpha2) && list.Count > 0)
			//{
			//	ObjectPool<Packdata>.Enqueue(list[0]);
			//	list.RemoveAt(0);
			//}

			if (Random.Range(0, 2) == 0)
			{
				Packdata _packet = (Packdata)ObjectPool<Packdata>.Dequeue();
				_packet.PlusCount();
				list.Add(_packet);
			}
			else if (list.Count > 0)
			{
				ObjectPool<Packdata>.Enqueue(list[0]);
				list.RemoveAt(0);
			}

			//Debug.Log(list.Count + ":" + ObjectPool<Packdata>.list.Count);
		}
	}
}