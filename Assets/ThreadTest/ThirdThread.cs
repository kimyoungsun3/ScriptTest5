using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

namespace ThreadTest
{
	public class ThirdThread
	{
		bool bApplicationQuie;
		Thread thread;
		MessageQueue messageQueue;

		public void Start(MessageQueue _messageQueue)
		{
			if(thread != null && thread.IsAlive)
			{
				return;
			}

			messageQueue		= _messageQueue;
			bApplicationQuie	= false;
			ThreadStart _ts		= new ThreadStart(delegate()
			{
				int _loop = 0;
				while (bApplicationQuie == false)
				{
					Debug.Log("Thread => Queue -> Unity");
					lock (messageQueue)
					{
						messageQueue.Enqueue(_loop++);
					}
					Thread.Sleep(10);
				}
			});

			thread = new Thread(_ts);
			thread.Start();
		}

		public void Abort()
		{
			bApplicationQuie = true;
		}
	}
}