using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MultiThread3 : MonoBehaviour
{
	Thread thread1 = null;
	Thread thread2 = null;
	bool isPlaying = true;
	public GameObject obj;
	Queue<Vector3> queueReceive = new Queue<Vector3>();
	Queue<Vector3> queueSend	= new Queue<Vector3>();
	// Start is called before the first frame update

	void Start()
	{
		thread1 = new Thread(OnAcceptAsync);
		thread2 = new Thread(OnSendAsync);
		thread1.Start();
		thread2.Start();
	}

	void OnAcceptAsync()
	{
		float _min = -10;
		float _max = +10;
		System.Random _rand = new System.Random();
		while (true)
		{
			if (isPlaying == false) break;

			Vector3 _pos = new Vector3((float)(_rand.NextDouble() * (_max - _min) + _min), 0, (float)(_rand.NextDouble() * (_max - _min) + _min));
			lock (queueReceive)
			{
				queueReceive.Enqueue(_pos);
				Debug.Log("<< " + _pos);
			}
			Thread.Sleep(100);
		}
	}

	void OnSendAsync()
	{
		while (true)
		{
			if (isPlaying == false) break;

			lock (queueSend)
			{
				if(queueSend.Count > 0)
				{
					Vector3 _pos = queueSend.Dequeue();
					Debug.Log(">> " + _pos);
				}
			}
			Thread.Sleep(100);
		}
	}


	// Update is called once per frame

	void Update()
	{
		//T1  queue.Enqueue(xx) >> 카운터 증후 >> 데이타를 넣는작업... 
		//							+1         >> T1X
		//UT  >>                    +OK 진행....  없네...

		Vector3 _pos = Vector3.zero;
		bool _bReceive = false;
		lock (queueReceive)
		{
			if (queueReceive.Count > 0)
			{
				_pos = queueReceive.Dequeue();
				_bReceive = true;
			}			
		}

		if (_bReceive)
		{
			GameObject _go = Instantiate(obj, _pos, Quaternion.identity) as GameObject;
			_go.SetActive(true);

			lock (queueSend)
			{
				queueSend.Enqueue(_pos);
			}			
		}			
	}

	private void OnDestroy()
	{
		isPlaying = false;
	}
}