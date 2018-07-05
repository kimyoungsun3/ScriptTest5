using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformChildTest : MonoBehaviour {
	public Transform target;
	public List<GameObject> list = new List<GameObject> ();
	float[] t = new float[10];
	public int count = 10000;

	void Start () {
		Debug.Log ("1,2,3,4");
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			F1 ();
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			F2 ();
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			t [0] = Time.realtimeSinceStartup;
			for (int i = 0; i < count; i++) {
				F1 ();
			}
			t [1] = Time.realtimeSinceStartup;
			Debug.Log("for:" + (t [1] - t [0]));
		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			t [0] = Time.realtimeSinceStartup;
			for (int i = 0; i < count; i++) {
				F2 ();
			}
			t [1] = Time.realtimeSinceStartup;
			Debug.Log("foreach:" + (t [1] - t [0]));
		} else if (Input.GetKeyDown (KeyCode.Alpha0)) {
			F0 ();
		}
	}
	void F0(){
		list.Clear ();
	}

	void F1(){
		list.Clear ();
		for (int i = 0, iMax = target.childCount; i < iMax; i++) {
			list.Add (target.GetChild (i).gameObject);
		}
	}

	void F2(){
		list.Clear ();
		foreach(Transform _t in target){
			list.Add (_t.gameObject);
		}		
	}

	void F3(){
	
	}

	void F4(){
	
	}
}
