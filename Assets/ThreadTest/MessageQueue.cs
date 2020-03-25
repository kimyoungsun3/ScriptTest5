using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreadTest
{
	public class MessageQueue
	{
		Queue<int> queue = new Queue<int>();

		public void Enqueue(int _val)
		{
			queue.Enqueue(_val);
		}

		public bool Check()
		{
			return queue.Count > 0;
		}

		public int Dequeue()
		{
			return queue.Dequeue();
		}
	}
}
