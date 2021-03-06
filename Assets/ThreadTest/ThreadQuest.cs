﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

namespace ThreadTest
{
	public class ThreadQuest : MonoBehaviour
	{

		public Transform prefab;
		Queue<int> queue = new Queue<int>();
		Transform trans;
		Transform holder;

		void Start()
		{
			trans = transform;

			if(holder == null)
			{
				holder = new GameObject("Holder").transform;
			}			
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
			ThreadStart _ts = new ThreadStart(delegate ()
			{
				Debug.Log(" ==== ThreadStart Start ===== ");
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
				Debug.Log(" ==== ThreadStart End ===== ");
			});
			thread = new Thread(_ts);
			thread.Start();
		}

		//전체 스레드를 종료해준다..
		//10개 모두 정상종료...
		bool bApplicationQuit = false;
		private void OnApplicationQuit()
		{
			bApplicationQuit = true;
		}
	}
}