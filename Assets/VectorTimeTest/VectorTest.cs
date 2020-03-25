using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorTest : MonoBehaviour {
	float[] t = new float[20];


	void Start(){
		Debug.Log ("1, 2, 3, 4, 5");
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Fun1 ();
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			Fun2 ();
		}
	}

	Vector3[] arrayV3		= new Vector3[100];
	List<Vector3> listV3	= new List<Vector3>();
	Dictionary<Vector3, Vector3> dicV3 = new Dictionary<Vector3, Vector3>();
	void Fun2(){
		Debug.Log (" foreach Test");
		Vector3 _v1 = Vector3.one;
		for (int i = 0, iMax = arrayV3.Length; i < iMax; i++) {
			arrayV3[i] = _v1;
		}

		foreach(Vector3 _v in listV3){
			_v1 = _v;
		}

		foreach(KeyValuePair<Vector3, Vector3> _kv in dicV3){
			_v1 = _kv.Key;
		}

	}

	void Fun1(){
		int count = 1000000;
		Vector3 v0 = Vector3.zero;
		Vector3 v;

		//------------------------------
		t [0] = Time.realtimeSinceStartup;
		for (int i = 0; i < count; i++) {
			v = v0;
		}

		t [1] = Time.realtimeSinceStartup;
		for (int i = 0; i < count; i++) {
			v = Vector3.zero;
		}

		t [2] = Time.realtimeSinceStartup;
		for (int i = 0; i < count; i++) {
			v = ConstantVector.VZSR;
		}

		t [3] = Time.realtimeSinceStartup;
		for (int i = 0; i < count; i++) {
			v = ConstantVector.VZS;
		}

		//------------------------------
		t [4] = Time.realtimeSinceStartup;
		for (int i = 0; i < count; i++) {
			v = v0;
		}

		t [5] = Time.realtimeSinceStartup;
		for (int i = 0; i < count; i++) {
			v = Vector3.zero;
		}

		t [6] = Time.realtimeSinceStartup;
		for (int i = 0; i < count; i++) {
			v = ConstantVector.VZSR;
		}

		t [7] = Time.realtimeSinceStartup;
		for (int i = 0; i < count; i++) {
			v = ConstantVector.VZS;
		}
		t [8] = Time.realtimeSinceStartup;

		Debug.Log ("Vector.zero 생성 테스트");
		Debug.Log (" v0:" + (t [1] - t [0]));
		Debug.Log (" Vector3.zero:" + (t [2] - t [1]));
		Debug.Log (" VZSR:" + (t [3] - t [2]));
		Debug.Log (" VZS:" + (t [4] - t [3]));

		Debug.Log (" v0:" + (t [5] - t [4]));
		Debug.Log (" Vector3.zero:" + (t [6] - t [5]));
		Debug.Log (" VZSR:" + (t [7] - t [6]));
		Debug.Log (" VZS:" + (t [8] - t [7]));

	}

}
