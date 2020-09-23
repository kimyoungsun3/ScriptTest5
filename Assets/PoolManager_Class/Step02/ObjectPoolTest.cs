using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoolManager_Class2
{
	[System.Serializable]
	public class PacketData
	{
		public static int indexSerial = 0;
		public int index;
		public int code;
		public int error;
		public int count = 0;
		//public Packet()
		//{
		//	index = indexSerial++;
		//	Debug.Log(index);
		//}

		public void Reset()
		{
			code = -1;
		}
		public void Used()
		{
			count++;
		}
	}

	public class ObjectPoolTest : MonoBehaviour
	{
		public List<PacketData> list_UsedPacket = new List<PacketData>();

		void Start()
		{
			ObjectPool<PacketData>.Initialize(100);
		}

		// Update is called once per frame
		void Update()
		{
			//if (Input.GetKey(KeyCode.Alpha1))
			//{
			//	list.Add(ObjectPool<Packet>.Dequeue());
			//}
			//else if (Input.GetKey(KeyCode.Alpha2) && list.Count > 0)
			//{
			//	ObjectPool<Packet>.Enqueue(list[0]);
			//	list.RemoveAt(0);
			//}

			if (Random.Range(0, 2) == 0)
			{
				PacketData _packet = (PacketData)ObjectPool<PacketData>.Dequeue();
				Debug.Log(_packet);
				_packet.Used();
				list_UsedPacket.Add(_packet);
			}
			else if (list_UsedPacket.Count > 0)
			{
				ObjectPool<PacketData>.Enqueue(list_UsedPacket[0]);
				list_UsedPacket.RemoveAt(0);
			}

			//Debug.Log(list.Count + ":" + ObjectPool<Packdata>.list.Count);
		}
	}
}