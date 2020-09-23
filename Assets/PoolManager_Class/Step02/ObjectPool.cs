using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoolManager_Class2
{
	public static class ObjectPool<T> where T : class
	{
		public static Queue<T> list = new Queue<T>();
		public static int maxCount;
		public static int useCount;
		static int percentCount;

		public static void Initialize(int _count)
		{
			maxCount	= _count;
			useCount	= 0;
			percentCount = 10;
			CreateObject(_count);
		}

		static void CreateObject(int _count)
		{
			for (int i = 0; i < _count; i++)
			{
				list.Enqueue(default(T));
			}
		}

		public static void Enqueue(T _t)
		{
			lock (list)
			{
				list.Enqueue(_t);
				useCount--;
			}
		}

		public static T Dequeue()
		{
			lock (list)
			{
				Debug.Log(list.Count + ":" + useCount + ":" + maxCount);
				if (useCount >= maxCount)
				{
					CreateObject(percentCount);
					maxCount += percentCount;
				}
				useCount++;
				return list.Dequeue();
			}
		}
	}
}