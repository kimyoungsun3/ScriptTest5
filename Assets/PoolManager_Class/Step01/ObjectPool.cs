using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoolManager_Class
{

	public static class ObjectPool<T> where T : class, new()
	{
		public static Queue<T> list = new Queue<T>();
		public static int maxCount;
		public static int useCount;
		static int percentCount;

		public static void Initialize(int _count)
		{
			maxCount = _count;
			useCount = 0;
			percentCount = 10;
			CreateObject(_count);
		}

		static void CreateObject(int _count)
		{
			for (int i = 0; i < _count; i++)
			{
				//list.Enqueue(default(T));
				// 생성되어 있지 않는다.. ㅠㅠ
				//
				//1. abstract + static하지않게 만들어서 팩토리메소드 abstract하게 넣던지
				//2. generic제약조건에 new ()넣던지
				//3. static setter로 팩토리메소드 집어넣으셔야할듯

				//해결법1...
				list.Enqueue(new T());

				//해결법2...
				//T _t		= System.Activator.CreateInstance<T>();
				//list.Enqueue(_t);
				//list.Enqueue(System.Activator.CreateInstance<T>());
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