using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

namespace ThreadTest
{
	public class ThreadQuest4 : MonoBehaviour
	{
		public Transform prefab;
		Transform trans;
		Transform holder;
		MessageQueue messageQueue;
		ThirdThread thirdThread;

		void Start()
		{
			trans	= transform;
			holder	= new GameObject("Holder").transform;

			messageQueue = new MessageQueue();
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{				
				if(thirdThread == null)
				{
					thirdThread = new ThirdThread();
				}
				thirdThread.Start(messageQueue);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				if (thirdThread != null)
					thirdThread.Abort();
			}

			bool _bCreate = false;
			lock (messageQueue)
			{
				if (messageQueue.Check())
				{
					messageQueue.Dequeue();
					_bCreate = true;
				}
			}

			if (_bCreate)
			{
				Transform _t = Instantiate(prefab, UnityEngine.Random.onUnitSphere * 5f, Quaternion.identity) as Transform;
				_t.SetParent(holder);
			}
		}

		//전체 스레드를 종료해준다..
		// 1개 정상...
		//10개 정상종료...
		private void OnApplicationQuit()
		{
			if(thirdThread != null)
			{
				thirdThread.Abort();
			}
		}
	}
}