using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PoolManager_Class_destructor2
{
	[System.Serializable]
	public class Packdata : System.IDisposable
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
			Dispose(false);
		}

		public void Dispose()
		{
			this.Dispose(true);
			System.GC.SuppressFinalize(this);
		}

		private bool disposed;
		protected virtual void Dispose(bool _disposing)
		{
			if (this.disposed) return;
			if (_disposing)
			{
				// IDisposable 인터페이스를 구현하는 멤버들을 여기서 정리합니다.
			}
			// .NET Framework에 의하여 관리되지 않는 외부 리소스들을 여기서 정리합니다.
			ObjectPool<Packdata>.Enqueue(this);
			this.disposed = true;
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
				//자동회수...
				//GC가 임의의 시간에 회수됨... >> 충분히 있는데 회수가 안되어서....
				//새롭게 생성을 한다....
				//ObjectPool<Packdata>.Enqueue(list[0]);
				list.RemoveAt(0);
			}

			Debug.Log(list.Count + ":" + ObjectPool<Packdata>.queue.Count);
		}
	}
}