using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoolManager_Class3
{
	[System.Serializable]
	public class PackData
	{
		public static int indexSequence;
		public int index;
		public int code;
		public int error;
		public int callCount;
		public PackData() {
			index = indexSequence++;
		}

		public void PlusCount()
		{
			callCount++;
		}

		//~Packdata()
		//{
		//	if (ObjectPoolTest.ins)
		//	{
		//		ObjectPoolTest.ins.list2.Add(this);
		//	}			
		//}
	}

	public class ObjectPoolTest : MonoBehaviour
	{
		public static ObjectPoolTest ins;
		public List<PackData> list = new List<PackData>();

		private void Awake()
		{
			ins = this;
		}

		void Start()
		{
			ClassPoolT<PackData>.Initialize(100);
		}

		PackData packSample;
		void Update()
		{
			//if (Input.GetKeyDown(KeyCode.C)) packSample = new Packdata();
			//if (Input.GetKeyDown(KeyCode.D))
			//{
			//	packSample.error = 99;
			//	packSample = null;
			//}

			if (Random.Range(0, 2) == 0)
			{
				PackData _packet = ClassPoolT<PackData>.Dequeue();
				_packet.PlusCount();
				list.Add(_packet);
			}
			else if (list.Count > 0)
			{
				ClassPoolT<PackData>.Enqueue(list[0]);
				list.RemoveAt(0);
			}

			Debug.Log(list.Count + ":" + ClassPoolT<PackData>.queue.Count);
		}
	}
}