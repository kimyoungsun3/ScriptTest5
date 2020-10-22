using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

namespace MultThread_OverloadTest
{
	public class ThreadData
	{
		public Thread thread;
		public bool isAlive = false;
		public ThreadData(Thread _t, bool _b)
		{
			thread = _t;
			isAlive = _b;
		}
	}

	public class MultiThread_Overload : MonoBehaviour
	{
		// Start is called before the first frame update
		object obj = new object();
		long powCnt = 0;
		List<ThreadData> threads = new List<ThreadData>();
		void Start()
		{
			//Debug.Log(Environment.ProcessorCount);

			for (int i = 0; i < Environment.ProcessorCount; i++)
			{
				Thread _t = new Thread(new ParameterizedThreadStart(Thread_XXX));
				ThreadData _td = new ThreadData(_t, true);
				threads.Add(_td);

				_t.Start(_td);
			}
		}

		void Thread_XXX(object _o)
		{
			ThreadData _td = (ThreadData)_o;
			while (_td.isAlive)
			{
				for (int u = 1; u < 500000; u++)
				{
				}

				lock (obj)
				{
					powCnt += 1;
				}
			}
		}


		void Update()
		{
			lock (obj)
			{
				Debug.Log("PcPower:" + powCnt);
			}
			//powCnt = 0; 
		}

		private void OnApplicationQuit()
		{
			Debug.Log("OnApplicationQuit 1");
			foreach (var th in threads)
			{
				th.isAlive = false;
			}
			Debug.Log("OnApplicationQuit 2");
		}

		private void OnDestroy()
		{
			Debug.Log("OnDestroy 1");
			foreach (var th in threads)
			{
				th.isAlive = false;
			}
			Debug.Log("OnDestroy 1");
		}
	}
}