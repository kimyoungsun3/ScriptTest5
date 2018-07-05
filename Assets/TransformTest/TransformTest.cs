using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTest : MonoBehaviour {
	float[] t = new float[10];
	public int LOOP = 100000;
	Transform trans;

	void Start(){
		trans = transform;
		Debug.Log ("1, 2, 3");
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {			
			t [0] = Time.realtimeSinceStartup;
			Fun1 ();

			t [1] = Time.realtimeSinceStartup;
			Fun2 ();

			t [2] = Time.realtimeSinceStartup;
			Fun3 ();

			t [3] = Time.realtimeSinceStartup;
			Debug.Log("Fun1:" + (t[1] - t[0]));
			Debug.Log("Fun2:" + (t[2] - t[1]));
			Debug.Log("Fun3:" + (t[3] - t[2]));
		}else if (Input.GetKeyDown (KeyCode.Alpha2)) {			
			t [0] = Time.realtimeSinceStartup;
			Fun2 ();

			t [1] = Time.realtimeSinceStartup;
			Fun3 ();

			t [2] = Time.realtimeSinceStartup;
			Fun1 ();

			t [3] = Time.realtimeSinceStartup;
			Debug.Log("Fun2:" + (t[1] - t[0]));
			Debug.Log("Fun3:" + (t[2] - t[1]));
			Debug.Log("Fun1:" + (t[3] - t[2]));
		}else if (Input.GetKeyDown (KeyCode.Alpha3)) {			
			t [0] = Time.realtimeSinceStartup;
			Fun3 ();

			t [1] = Time.realtimeSinceStartup;
			Fun1 ();

			t [2] = Time.realtimeSinceStartup;
			Fun2 ();

			t [3] = Time.realtimeSinceStartup;
			Debug.Log("Fun3:" + (t[1] - t[0]));
			Debug.Log("Fun1:" + (t[2] - t[1]));
			Debug.Log("Fun2:" + (t[3] - t[2]));
		}
	}

	void Fun1(){
		int i;
		float x;
		for (i = 0; i < LOOP; i++) {
			x = trans.position.x;
		}
	}

	void Fun2(){
		int i;
		float x;
		for (i = 0; i < LOOP; i++) {
			x = transform.position.x;
		}
	}

	void Fun3(){
		int i;
		float x;
		for (i = 0; i < LOOP; i++) {
			x = GetComponent<Transform> ().position.x;
		}
	}

}
