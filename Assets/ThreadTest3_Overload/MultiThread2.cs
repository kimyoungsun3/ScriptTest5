using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine.UI;

namespace MultThread_OverloadTest
{
	public class MultiThread2 : MonoBehaviour
	{
		public Text text;
		string netTime;
		Thread th1;
		//Thread th2;
		int cnt = 0;
		bool isPlaying = true;

		void Start()
		{
			//th1 = new Thread(new ThreadStart(ThreadFun));
			th1 = new Thread(Thread2Func);
			th1.Start();
			//th2 = new Thread(Thread2Func);
			//th2.Start();
		}

		void ThreadFun()
		{
			while (true)
			{
				cnt++;
				Thread.Sleep(1000);
			}
		}

		private void OnDestroy()
		{
			//if (th1.IsAlive) th1.Abort();
			//if (th2.IsAlive) th2.Abort();
			isPlaying = false;
		}

		// Update is called once per frame
		void Update()
		{
			//Debug.Log($"{1f / Time.deltaTime:0.0}fps//{cnt}");
			//Debug.Log(cnt);
			text.text = $"{ netTime}";//StringBuilder
		}


		public string[] serverList = new string[]
		{
		"time.windows.com",
		"pool.ntp.org",
		"time.google.com",
		"time.apple.com",
		"time.cloudflare.com",
		"time.facebook.com",
		"time.nist.gov",
		};

		void Thread2Func()
		{
			while (true)
			{	
				foreach (var s in serverList)
				{
					DateTime t = DateTime.MinValue;
					var st = new System.Diagnostics.Stopwatch();
					st.Start();
					try
					{
						t = GetNetworkTime(s).AddHours(9);
						Debug.Log($"{s} : {t} ping:{st.ElapsedMilliseconds}ms");
						netTime = t.ToString();
						break;
					}
					catch (Exception ex)
					{
						Debug.Log(ex);
					}
				}
				
				Thread.Sleep(1000);
				if (isPlaying == false) break;
			}
		}

		public static DateTime GetNetworkTime(string serverUrl)
		{
			string ntpServer = serverUrl;
			var ntpData = new byte[48];
			ntpData[0] = 0x1B;
			IPAddress[] addresses = Dns.GetHostEntry(ntpServer).AddressList;
			var ipEndPoint = new IPEndPoint(addresses[0], 123);
			using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
			{
				socket.Connect(ipEndPoint);
				socket.ReceiveTimeout = 1000;
				socket.Send(ntpData);
				socket.Receive(ntpData);
				socket.Close();
			}
			ulong intPart = (ulong)ntpData[40] << 24 | (ulong)ntpData[41] << 16 | (ulong)ntpData[42] << 8 | (ulong)ntpData[43];
			ulong fractPart = (ulong)ntpData[44] << 24 | (ulong)ntpData[45] << 16 | (ulong)ntpData[46] << 8 | (ulong)ntpData[47];
			var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
			var networkDateTime = (new DateTime(1900, 1, 1)).AddMilliseconds((long)milliseconds);
			return networkDateTime;
		}
	}
}