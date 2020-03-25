using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

namespace ThreadTest
{
	public class ThreadQuest2 : MonoBehaviour
	{

		public Transform prefab;
		Queue<int> queue = new Queue<int>();
		Transform trans;
		Transform holder;

		void Start()
		{
			trans = transform;

			holder = new GameObject("Holder").transform;
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				DoTest();
			}


			bool _bCreate = false;
			lock (queue)
			{
				if (queue.Count > 0)
				{
					queue.Dequeue();
					_bCreate = true;
				}
			}

			if (_bCreate)
			{
				Transform _t = Instantiate(prefab, UnityEngine.Random.onUnitSphere * 5f, Quaternion.identity) as Transform;
				_t.SetParent(holder);
			}
		}


		Thread thread;
		void DoTest()
		{
			if (thread != null && thread.IsAlive) return;

			ThreadStart _ts = new ThreadStart(delegate ()
			{
				int _loop = 0;
				while (true)
				{
					Debug.Log("Thread => Queue -> Unity");
					lock (queue)
					{
						queue.Enqueue(_loop++);
					}
					Thread.Sleep(1000);
				}
			});
			thread = new Thread(_ts);
			thread.Start();
		}

		//1개 정상 종료...
		//10개 1개만 종료가 되고 나머지는 종료가 안된다...
		private void OnApplicationQuit()
		{
			if (thread != null && thread.IsAlive)
			{
				Debug.Log(thread.IsAlive);
				thread.Interrupt();
				thread.Abort();
				//이방법은 문제가 있다... 스레드있느 개수만큼 강제 종료해줘야한다...
			}
		}
	}
}