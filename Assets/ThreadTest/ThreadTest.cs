using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;


public class ThreadTest : MonoBehaviour {
	public Transform prefab;
	Queue<GameObject> queue = new Queue<GameObject>();
	Transform holder;
	Transform mytran;
	GameObject mygo;
	int num = 0;

	void Start () {
		Debug.Log ("1, 2 Thread create/destroy gameobject");
		mytran = transform;
		mygo = gameObject;
		latestScale = mytran.localScale;

		holder = mytran.Find ("holder");
		if (holder == null) {
			holder = new GameObject ("holder").transform;
		}
		holder.SetParent (mytran);
	}


	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Test01 ();
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			Test02 ();
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			Test03 ();
		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			Test04 ();
		} else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			Test05 ();
		} else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			Test06 ();
		} else if (Input.GetKeyDown (KeyCode.Alpha7)) {
			Test07 ();
		} else if (Input.GetKeyDown (KeyCode.Alpha8)) {
			Test08 ();
		}

		if (mytran.localScale != latestScale) {
			mytran.localScale = latestScale;
		}

		if (queue8.Count > 0) {
			int _c = queue8.Dequeue ();
			Debug.Log (_c);
			Transform _t = Instantiate (prefab, UnityEngine.Random.onUnitSphere * 5f, Quaternion.identity) as Transform;
			_t.SetParent (holder);
			queue.Enqueue (_t.gameObject);
		}
	}

	//error
	void Test01(){
		//무한루프.... 왜????
		num++;
		Debug.Log (11);
		ThreadStart _ts = delegate() {
			Debug.Log (12);
			while(true){
				Debug.Log (13);
				Debug.Log("Thread("+num+") Instance -> Enqueue");

				Transform _t = Instantiate(prefab, UnityEngine.Random.onUnitSphere* 5f, Quaternion.identity) as Transform;
				_t.SetParent(holder);
				queue.Enqueue(_t.gameObject);
				Thread.Sleep(100);
			}
		};
		Thread _tt = new Thread (_ts);
		_tt.Start ();
		//_thread.Invoke ();
	}

	void Test02(){
		Debug.Log (" --- call nonstop count --- ");
		ThreadStart _ts = new ThreadStart (delegate() {
			for(int i = 0; i < 5; i++){
				Debug.Log("count : " + i);
				//Thread.Sleep(100); //error
			}
		});
		Thread _t = new Thread (_ts);
		_t.Start ();
		Debug.Log ("------Start Thread end-----");

	}

	void Test03(){
		Debug.Log (" --- call nonstop count/abort --- ");
		ThreadStart _ts = new ThreadStart (delegate() {
			for(int i = 0; i < 5; i++){
				Debug.Log("count : " + i);
				//Thread.Sleep(100);
			}
		});
		Thread _t = new Thread (_ts);
		_t.Start ();
		_t.Abort ();	//제대로 작동안함???
		Debug.Log ("------Start/Abort Thread end-----");

	}

	void Test04(){
		Debug.Log (" --- call Sleep count/abort --- ");
		ThreadStart _ts = new ThreadStart (delegate() {
			for(int i = 0; i < 5; i++){
				Debug.Log("count : " + i + ":" + Fun04());
				Thread.Sleep(1000);
			}
		});
		Thread _t = new Thread (_ts);
		_t.Start ();
		Debug.Log ("------Start Thread end-----");
	}

	float Fun04(){
		return 1f;
		//return Time.realtimeSinceStartup;// error -> 구조상....
	}

	//error
	void Test05(){
		ThreadStart _ts = new ThreadStart(delegate() {
			Debug.Log (12);
			while(true){
				Debug.Log (13);
				Debug.Log("Thread("+num+") Instance -> Enqueue");
				//Instantiate error....
				//Transform _t = Instantiate(prefab, UnityEngine.Random.onUnitSphere* 5f, Quaternion.identity) as Transform;
				//_t.SetParent(holder);
				//queue.Enqueue(_t.gameObject);
				Thread.Sleep(100);
			}
		});
		Thread _thread = new Thread (_ts);
		_thread.Start ();

	}

	Queue<string> queue2 = new Queue<string>();
	int count2, num2;
	void Test06(){
		int _num = num2++;
		ThreadStart _ts = new ThreadStart (delegate() {
			while(count2 < 10){
				count2++;
				queue2.Enqueue(_num + ":" + count2);
				Debug.Log(_num + ":" + count2);
				Thread.Sleep(1000);
			}
		});
		Thread _thread = new Thread (_ts);
		_thread.Start ();
	}

	Vector3 latestScale;
	void Test07(){
		latestScale = mytran.localScale;
		ThreadStart _ts = new ThreadStart(delegate() {
			while(true){
				//Debug.Log(7);
				//mytran.Translate(Vector3.forward * 1f);		-> error

				//mytran.localScale += Vector3.one * 0.001f;	-> error
				latestScale += Vector3.one * 0.001f;			//-> ok
				Thread.Sleep(100);
			}
		});
		Thread _thread = new Thread (_ts);
		_thread.Start ();
	}


	Queue<int> queue8 = new Queue<int>();
	int count8 = 0;
	void Test08(){
		latestScale = mytran.localScale;
		ThreadStart _ts = new ThreadStart(delegate() {
			while(true){
				//Debug.Log(8);
				//mytran.Translate(Vector3.forward * 1f);		-> error
				queue8.Enqueue(count8++);
				Thread.Sleep(100);
			}
		});
		Thread _thread = new Thread (_ts);
		_thread.Start ();
	}
}
