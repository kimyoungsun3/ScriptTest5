using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

namespace ThreadTest
{
	public class ThreadQuest3 : MonoBehaviour
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
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				bApplicationQuit = true;
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


		bool bApplicationQuit;
		Thread thread;
		void DoTest()
		{
			if (thread != null && thread.IsAlive)
				return;
			bApplicationQuit = false;
			ThreadStart _ts = new ThreadStart(delegate ()
			{
				int _loop = 0;
				while (!bApplicationQuit)
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

		//전체 스레드를 종료해준다..
		// 1개 정상...
		//10개 정상종료...
		private void OnApplicationQuit()
		{
			bApplicationQuit = true;
		}
	}
}