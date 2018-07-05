using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassAndStructNewTest : MonoBehaviour {
	public int countNew = 10000;
	public int countUse = 1000;
	public int countUseSub = 20;
	GameObject go;
	Transform tran;
	float[] time= new float[10];

	void Start(){
		go = gameObject;
		tran = transform;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			SubClass _s;
			time [0] = Time.realtimeSinceStartup;
			for (int i = 0; i < countNew; i++) {
				_s = new SubClass (go, 1, tran.position);
			}
			time [1] = Time.realtimeSinceStartup;

			Debug.Log("Class new ["+countNew+"]:" + (time [1] - time [0]));
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			SubStruct _s;
			time [0] = Time.realtimeSinceStartup;
			for (int i = 0; i < countNew; i++) {
				_s = new SubStruct (go, 1, tran.position);
			}
			time [1] = Time.realtimeSinceStartup;

			Debug.Log("Struct new ["+countNew+"]:" + (time [1] - time [0]));
		}else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			time [0] = Time.realtimeSinceStartup;
			SubClass _s = new SubClass (go, 0, tran.position);
			for (int i = 0; i < countUse; i++) {
				FunC (_s, countUseSub);
			}
			time [1] = Time.realtimeSinceStartup;
			Debug.Log("Class using ["+countNew+"]:" + (time [1] - time [0]) + ":" + _s.x);

		}else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			time [0] = Time.realtimeSinceStartup;
			SubStruct _s = new SubStruct (go, 0, tran.position);
			for (int i = 0; i < countUse; i++) {
				FunS (_s, countUseSub);
			}
			time [1] = Time.realtimeSinceStartup;
			Debug.Log("Struct using ["+countNew+"]:" + (time [1] - time [0]) + ":" + _s.x);

		}else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			time [0] = Time.realtimeSinceStartup;
			SubStruct _s = new SubStruct (go, 0, tran.position);
			for (int i = 0; i < countUse; i++) {
				FunS2 (ref _s, countUseSub);
			}
			time [1] = Time.realtimeSinceStartup;
			Debug.Log("Struct using(ref) ["+countNew+"]:" + (time [1] - time [0]) + ":" + _s.x);

		}
		
	}

	void FunC(SubClass _s, int _count){
		_count--;
		if (_count <= 0) {
			return;
		} else {
			FunC (_s, _count);
			_s.x++;
		}
	}

	void FunS(SubStruct _s, int _count){
		_count--;
		if (_count <= 0) {
			return;
		} else {
			FunS (_s, _count);
			_s.x++;
		}
	}

	void FunS2(ref SubStruct _s, int _count){
		_count--;
		if (_count <= 0) {
			return;
		} else {
			FunS2 (ref _s, _count);
			_s.x++;
		}
	}


	public class SubClass{
		public GameObject go;
		public int x;
		public Vector3 pos;

		public SubClass (GameObject _go, int _x, Vector3 _pos){
			go = _go;
			x = _x;
			pos = _pos;
		}
	}

	public struct SubStruct{
		public GameObject go;
		public int x;
		public Vector3 pos;

		public SubStruct (GameObject _go, int _x, Vector3 _pos){
			go = _go;
			x = _x;
			pos = _pos;
		}
	}
}
