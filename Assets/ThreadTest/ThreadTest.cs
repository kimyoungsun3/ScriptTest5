using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;


namespace ThreadTest
{
	[System.Serializable]public class MyClass
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
	public class ThreadTest : MonoBehaviour
	{
		public Transform prefab;
		Queue<GameObject> queue = new Queue<GameObject>();
		Transform holder;
		Transform trans;
		GameObject go;
		int num = 0;
		Queue<MyClass> queueClass = new Queue<MyClass>();

		void Start()
		{
			Debug.Log("1, 2 Thread create/destroy gameobject");
			trans	= transform;
			go		= gameObject;

			holder = trans.Find("holder");
			if (holder == null)
			{
				holder = new GameObject("holder").transform;
			}
			holder.SetParent(trans);
		}


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
				Test03();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				Test04();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha5))
			{
				Test05();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha6))
			{
				Test06();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha7))
			{
				Test07();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha8))
			{
				Test08();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha9))
			{
				Test09();
			}

			if (trans.localScale != beforeScale)
			{
				trans.localScale = beforeScale;
			}

			Debug.Log("Update 02");
			lock (queue8)
			{
				if (queue8.Count > 0)
				{
					int _c = queue8.Dequeue();
					Transform _t = Instantiate(prefab, UnityEngine.Random.onUnitSphere * 5f, Quaternion.identity) as Transform;
					_t.SetParent(holder);
					queue.Enqueue(_t.gameObject);

					Debug.Log("Test08 Unity3d  <= Queue(8)  Thread ");
				}
			}

			Debug.Log("Update 03");

			Debug.Log("Update 04");
			lock (actionQueue)
			{
				if(actionQueue.Count > 0)
				{
					Debug.Log("Test09 Unity3d  <=  Queue(9)    Thread ");
					actionQueue.Dequeue().Invoke();
				}
			}
			Debug.Log("Update 05");

			lock (queueClass)
			{	
				while (queueClass.Count > 0)
				{
					Debug.Log(Time.frameCount + ":" + queueClass.Dequeue().ToString());
				}
			}
		}

		//error
		void Fun01()
		{
			//무한루프.... 왜????

			Debug.Log(" Fun01 1");
			ThreadStart _ts = delegate ()
			{
				Debug.Log(" Fun01 2 >> ThreadStart 01");
				//while(true)
				//정상 처리로 벗어나게 해야함....
				//안되면 무한 루프에 빠짐...
				//compile로 빠짐....
				//error로 빠짐...
				int loop = 0;

				while (!bApplicationQuit)
				{
					Debug.Log(" Fun01 2 >> ThreadStart 02");

					//float x = Screen.width;
					//lock (queue6){ queue6.Enqueue("1");}
					loop++;
					lock (queueClass) {
						queueClass.Enqueue(new MyClass(loop, loop, "" + loop));
					}
					//lock (actionQueue) {
					//	actionQueue.Enqueue(delegate ()
					//	{
					//		Transform _t = Instantiate(prefab, UnityEngine.Random.onUnitSphere * 5f, Quaternion.identity) as Transform;
					//		_t.SetParent(holder);
					//	});
					//}

					//Vector3 _pos = Input.mousePosition;
					//float _h = Input.GetAxisRaw("Horizontal");
					//Camera _c = Camera.main;
					//GameObject _go = gameObject;
					//Transform _t = transform;
					//Rigidbody _r = GetComponent<Rigidbody>();
					//Transform _t = Instantiate(prefab, UnityEngine.Random.onUnitSphere * 5f, Quaternion.identity) as Transform;
					//_t.SetParent(holder);
					//queue.Enqueue(_t.gameObject);
					Thread.Sleep(10);
					Debug.Log(" Fun01 2 >> ThreadStart 03");
				}
				Debug.Log(" Fun01 2 >> ThreadStart 04");
			};

			Debug.Log(" Fun01 3");
			Thread _tt = new Thread(_ts);

			Debug.Log(" Fun01 4");
			_tt.Start();
			//_thread.Invoke ();
			Debug.Log(" Fun01 5 "); 
		}

		void Fun02()
		{
			Debug.Log(" --- call nonstop count --- ");
			ThreadStart _ts = new ThreadStart(delegate ()
			{
				Debug.Log(" ==== ThreadStart Start ===== ");
				for (int i = 0; i < 5; i++)
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

		void Test03()
		{
			Debug.Log(" --- call nonstop count/abort --- ");
			ThreadStart _ts = new ThreadStart(delegate ()
			{
				for (int i = 0; i < 5; i++)
				{
					Debug.Log("count : " + i);
					//Thread.Sleep(100);
				}
			});
			Thread _t = new Thread(_ts);
			_t.Start();
			//_t.Abort();
			Debug.Log("------Start/Abort Thread end-----");
		}

		void Test04()
		{
			Debug.Log(" --- call Sleep count/abort --- ");
			ThreadStart _ts = new ThreadStart(delegate ()
			{
				for (int i = 0; i < 5; i++)
				{
					//Debug.Log(Time.deltaTime);
					Debug.Log("count : " + i + ":" + Fun04());
					Thread.Sleep(1000);
				}
			});
			Thread _t = new Thread(_ts);
			_t.Start();
			Debug.Log("------Start Thread end-----");
		}

		float f4v;
		float Fun04()
		{
			f4v += 1f;
			return f4v;
			//return Time.realtimeSinceStartup;// error -> 구조상....
		}

		void Test05()
		{
			ThreadStart _ts = new ThreadStart(delegate ()
			{
				Debug.Log(12);
				while (!bApplicationQuit)
				{
					Debug.Log(13);
					Debug.Log("Thread(" + num + ") Instance -> Enqueue");
					//Instantiate error....
					//Transform _t = Instantiate(prefab, UnityEngine.Random.onUnitSphere* 5f, Quaternion.identity) as Transform;
					//_t.SetParent(holder);
					//queue.Enqueue(_t.gameObject);
					Thread.Sleep(1000);
				}
			});
			Thread _thread = new Thread(_ts);
			_thread.Start(); 
		}

		Queue<string> queue6 = new Queue<string>();
		int count6, num6;
		void Test06()
		{
			int _num = num6++;
			ThreadStart _ts = new ThreadStart(delegate ()
			{
				string _msg;
				while (count6 < 5)
				{
					count6++;
					_msg = _num + ":" + count6;
					lock (queue)
					{
						queue6.Enqueue(_msg);
					}
					Debug.Log(_msg);
					Thread.Sleep(1000);
				}
			});
			Thread _thread = new Thread(_ts);
			_thread.Start();
		}

		[SerializeField]Vector3 beforeScale;
		void Test07()
		{
			beforeScale = trans.localScale;
			ThreadStart _ts = new ThreadStart(delegate ()
			{
				while (!bApplicationQuit)
				{
					Debug.Log("Test07 1");
					Transform _t; //이것은 되는데 무쓸모....
					//Transform _t2 = transform;				//error
					//trans.position = Vector3.zero;			//error
					//trans.Translate(Vector3.forward * 1f);    //-> error

					//trans.localScale += Vector3.one * 0.001f;	//-> error
					beforeScale += Vector3.one * 0.001f;        

					Debug.Log("Test07 2");
					Thread.Sleep(100);
				}
			});
			Thread _thread = new Thread(_ts);
			_thread.Start();
		}


		Queue<int> queue8 = new Queue<int>();
		int count8 = 0;
		void Test08()
		{
			beforeScale = trans.localScale;
			ThreadStart _ts = new ThreadStart(delegate ()
			{
				//if (!Application.isPlaying)//error
				while (!bApplicationQuit)
				{
					Debug.Log("Test08 Unity3d   Queue(8) <= Thread");
					lock (queue8)
					{
						queue8.Enqueue(count8++);
					}
					Thread.Sleep(1000);
				}
			});
			Thread _thread = new Thread(_ts);
			_thread.Start();
		}

		[SerializeField] bool bApplicationQuit = false;
		void OnApplicationQuit()
		{
			bApplicationQuit = true;
		}

		Queue<Action> actionQueue = new Queue<Action>();
		void Test09()
		{
			ThreadStart _ts = delegate ()
			{
				while (!bApplicationQuit)
				{
					Debug.Log("Test09 Unity3d     Queue(9) <= Thread ");
					Action _on = delegate (){
						Transform _t = Instantiate(prefab, UnityEngine.Random.onUnitSphere * 5f, Quaternion.identity) as Transform;
						_t.SetParent(holder);
					};
					//gameObject.SetActive(false);

					lock (actionQueue) 
					{ 
						actionQueue.Enqueue(_on);
					}
					Thread.Sleep(1000);
				}
			};
			Thread _tt = new Thread(_ts);
			_tt.Start();
		}
	}
}