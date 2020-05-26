using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

namespace TTTT
{
	[System.Serializable] public class MyClass
	{
		public int x1;
		public float x2;
		public string x3;
		public MyClass(int _x1, float _x2, string _x3)
		{
			x1 = _x1;
			x2 = _x2;
			x3 = _x3;
		}

		public override string ToString()
		{
			return "x1:" + x1 + " x2:" + x2 + " x3:" + x3;
		}
	}

	public class TT : MonoBehaviour
	{
		Transform trans;
		GameObject go;
		Transform holder;
		public Transform prefab;
		Queue<GameObject> queue		= new Queue<GameObject>();
		Queue<MyClass> queueClass	= new Queue<MyClass>();
		[SerializeField] Vector3 beforeScale;
		// Use this for initialization
		void Start()
		{
			trans = transform;
			go = gameObject;

			holder = trans.Find("Holder");
			if(holder == null)
			{
				holder = new GameObject("Holder").transform;
				holder.SetParent(trans);
			}
		}

		// Update is called once per frame
		void Update()
		{
			Debug.Log("Update 01");
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				Fun01();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				Fun02();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				Fun03();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				Fun04();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha5))
			{
				Fun05();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha6))
			{
				Fun06();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha7))
			{
				Fun07();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha8))
			{
				Fun08();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha9))
			{
				Fun09();
			}

			if(trans.localScale != beforeScale)
			{
				trans.localScale = beforeScale;
			}

			Debug.Log("Update 02");
			lock (queue6)
			{
				while(queue6.Count > 0)
				{
					Debug.Log(" >>= " + queue6.Dequeue());
				}
			}

			Debug.Log("Update 03");
			lock (queue8)
			{
				while(queue8.Count > 0)
				{
					int _c = queue8.Dequeue();
					Transform _t = Instantiate(prefab, UnityEngine.Random.onUnitSphere * 5f, Quaternion.identity);
					_t.SetParent(holder);
					queue.Enqueue(_t.gameObject);
					Debug.Log("Test08 Unity3d  <= Queue(8)  Thread ");
				}
			}

			Debug.Log("Update 04");
			lock (actionQueue)
			{
				while(actionQueue.Count > 0)
				{
					Debug.Log("Test09 Unity3d  <=  Queue(9)    Thread ");
					actionQueue.Dequeue().Invoke();
				}
			}

			Debug.Log("Update 05");
			lock (queueClass)
			{
				while(queueClass.Count > 0)
				{
					Debug.Log(Time.frameCount + " : " + queueClass.Dequeue().ToString());
				}
			}
		}

		void Fun01()
		{
			Debug.Log(" Fun01 1");
			ThreadStart _ts = delegate ()
			{
				Debug.Log(" Fun01 2 >> ThreadStart 01");
				int _loop = 0;

				while (!bApplicationQuit)
				{
					Debug.Log(" Fun01 2 >> ThreadStart 02");
					_loop++;
					lock (queueClass)
					{
						queueClass.Enqueue(new MyClass(_loop, _loop, _loop.ToString()));
					}
					Thread.Sleep(10);
					Debug.Log(" Fun01 2 >> ThreadStart 03");
				}
				Debug.Log(" Fun01 2 >> ThreadStart 04");
			};

			Debug.Log(" Fun01 3");
			Thread _t = new Thread(_ts);

			Debug.Log(" Fun01 4");
			_t.Start();
			Debug.Log(" Fun01 5 ");

		}

		void Fun02()
		{
			Debug.Log(" --- call nonstop count --- ");
			ThreadStart _ts = new ThreadStart(delegate ()
			{
				Debug.Log(" ==== ThreadStart Start ===== ");
				for(int i = 0; i < 5; i++)
				{
					Debug.Log("count : " + i);
					Thread.Sleep(2000);
				}
				Debug.Log(" ==== ThreadStart End ===== ");

			});
			Thread _t = new Thread(_ts);
			_t.Start();
			Debug.Log("------Start Thread end-----");
		}

		void Fun03()
		{
			Debug.Log(" --- call nonstop count --- ");
			ThreadStart _ts = new ThreadStart(delegate ()
			{
				Debug.Log(" ==== ThreadStart Start ===== ");
				for (int i = 0; i < 5; i++)
				{
					Debug.Log("count : " + i);
					//Thread.Sleep(2000);
				}
				Debug.Log(" ==== ThreadStart End ===== ");

			});
			Thread _t = new Thread(_ts);
			_t.Start();
			Debug.Log("------Start Thread end-----");

		}

		void Fun04()
		{
			Debug.Log(" --- call Sleep count/abort --- ");
			int _v1 = 0;
			ThreadStart _ts = new ThreadStart(delegate ()
			{
				int _v2 = 0;
				Debug.Log(" ==== ThreadStart Start ===== ");
				for (int i = 0; i < 5; i++)
				{
					int _v3 = Fun04Sub();
					Debug.Log("count : " + i + " _v1:" + (_v1++) + " _v2:" + (_v2++) + " _v3:" + _v3);
					Thread.Sleep(1000);
				}
				Debug.Log(" ==== ThreadStart End ===== ");
			});
			Thread _t = new Thread(_ts);
			_t.Start();
			Debug.Log("------Start Thread end-----");


		}

		int f04 = 0;
		int Fun04Sub()
		{
			return f04++;
		}

		void Fun05()
		{
			ThreadStart _ts = () => {
				Debug.Log(12);
				while (!bApplicationQuit)
				{
					Debug.Log(13);
					Debug.Log("Thread(" + Thread.CurrentThread.ManagedThreadId + ") Instance -> Enqueue");
					Thread.Sleep(1000);
				}
				Debug.Log(14);
			};
			Thread _t = new Thread(_ts);
			_t.Start();
		}

		Queue<string> queue6 = new Queue<string>();
		void Fun06()
		{
			int _pid = Thread.CurrentThread.ManagedThreadId;
			Thread _t = new Thread(()=> {
				Debug.Log(" ==== ThreadStart Start ===== ");
				string _msg;
				int _count = 0;
				while (_count < 5)
				{
					_count++;
					int _cid = Thread.CurrentThread.ManagedThreadId;
					_msg = "[" + _pid +  " / " + _cid + "]"
							+ " >> " + _count;
					lock (queue6)
					{
						queue6.Enqueue(_msg);
					}
					Debug.Log(" <<= " + _msg);
					Thread.Sleep(1000);
				}
				Debug.Log(" ==== ThreadStart End ===== ");
			});
			_t.Start();
		}

		void Fun07()
		{
			beforeScale = trans.localScale;
			Thread _t = new Thread(()=>
			{
				Debug.Log(" ==== ThreadStart Start ===== ");
				while (!bApplicationQuit)
				{
					beforeScale += Vector3.one * 0.001f;
					Thread.Sleep(100);
				}
				Debug.Log(" ==== ThreadStart End ===== ");
			});
			_t.Start();

		}

		Queue<int> queue8 = new Queue<int>();		
		void Fun08()
		{
			Thread _t = new Thread(() => {
				Debug.Log(" ==== ThreadStart Start ===== ");
				while (!bApplicationQuit)
				{
					lock (queue8)
					{
						queue8.Enqueue(+1);
					}
					Debug.Log("Test08 Unity3d   Queue(8) <= Thread");
					Thread.Sleep(1000);
				}
				Debug.Log(" ==== ThreadStart End ===== ");
			});
			_t.Start();
		}

		Queue<Action> actionQueue = new Queue<Action>();
		void Fun09()
		{
			ThreadStart _ts = new ThreadStart(delegate()
			{
				Debug.Log(" ==== ThreadStart Start ===== ");
				while (!bApplicationQuit)
				{					
					Action _cb = delegate ()
					{
						Transform _t = Instantiate(prefab, UnityEngine.Random.onUnitSphere * 5f, Quaternion.identity);
						_t.SetParent(holder);
						queue.Enqueue(_t.gameObject);
					};

					lock (actionQueue)
					{
						actionQueue.Enqueue(_cb);
					}
					Debug.Log("Test09 Unity3d     Queue(9) <= Thread ");
					Thread.Sleep(1000);
				}

				Debug.Log(" ==== ThreadStart End ===== ");
			});
			Thread _tt = new Thread(_ts);
			_tt.Start();
		}

		[SerializeField] bool bApplicationQuit = false;
		private void OnApplicationQuit()
		{
			bApplicationQuit = true;
		}
	}
}
