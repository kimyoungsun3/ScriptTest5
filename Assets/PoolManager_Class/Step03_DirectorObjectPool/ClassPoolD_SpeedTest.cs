﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoolManager_Class3
{
	public class ClassPoolD_SpeedTest : MonoBehaviour
	{
		List<PackData> list = new List<PackData>();


		void Start()
		{
			t[0] = Time.realtimeSinceStartup;
			ClassPoolD.Initialize(1000);
			t[1] = Time.realtimeSinceStartup;
			Fun1();
			t[2] = Time.realtimeSinceStartup;
			Fun1();
			t[3] = Time.realtimeSinceStartup;
			Fun1();
			t[4] = Time.realtimeSinceStartup;
			Fun1();
			t[5] = Time.realtimeSinceStartup;
			Debug.Log("OPD Loop:" + LOOP_MAX);
			Debug.Log("OPD create:" + (t[1] - t[0]));
			Debug.Log("OPD pool:" + (t[2] - t[1]));
			Debug.Log("OPD pool:" + (t[3] - t[2]));
			Debug.Log("OPD pool:" + (t[4] - t[3]));
			Debug.Log("OPD pool:" + (t[5] - t[4]));


			for (int i = 0; i < 10; i++)
			{
				t[0] = Time.realtimeSinceStartup;
				Fun1();
				t[1] = Time.realtimeSinceStartup;
				Debug.Log(i + " OPD direct:" + (t[1] - t[0]));
			}
		}


		public int LOOP_MAX = 10000 * 10;
		public float[] t = new float[10];
		void Fun1()
		{
			PackData _packet;
			int _rr = 0;
			for (int i = 0; i < LOOP_MAX; i++)
			{
				//int _rand = Random.Range(0, 2);
				int _rand = _rr++ % 2;
				if (_rand == 0)
				{
					_packet = ClassPoolD.Dequeue();
					_packet.PlusCount();
					list.Add(_packet);
				}
				else if (list.Count > 0)
				{
					ClassPoolD.Enqueue(list[0]);
					list.RemoveAt(0);
				}
			}
			//Debug.Log(list.Count + ":" + ObjectPool<PackData>.queue.Count);
		}
	}
}