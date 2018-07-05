using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpeedTest{
	public class FindObjectScript : MonoBehaviour {
		void Start(){
			Debug.Log ("1:ObjectFind, 2:For, Foreach Speed Test");
		}


		float[] t = new float[10];
		public int count = 1000;
		void Update () {
			//Debug.Log (1);
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				GameObject _go;
				Player _player;
				//Debug.Log ("Start"); 

				t [0] = Time.realtimeSinceStartup;
				for (int i = 0; i < count; i++) {
					_go = GameObject.Find ("Player");
					if (_go != null) {
						_player = _go.GetComponent<Player> ();
					}
				}
				t [1] = Time.realtimeSinceStartup;


				for (int i = 0; i < count; i++) {
					_go = GameObject.FindGameObjectWithTag ("Player");
					if (_go != null) {
						_player = _go.GetComponent<Player> ();
					}
				}
				t [2] = Time.realtimeSinceStartup;


				for (int i = 0; i < count; i++) {
					_player = FindObjectOfType<Player> ();
				}
				t [3] = Time.realtimeSinceStartup;


				for (int i = 0; i < count; i++) {
					_go = GameObject.Find ("Player");
					if (_go != null) {
						_player = _go.GetComponent<Player> ();
					}
				}
				t [4] = Time.realtimeSinceStartup;


				for (int i = 0; i < count; i++) {
					_go = GameObject.FindGameObjectWithTag ("Player");
					if (_go != null) {
						_player = _go.GetComponent<Player> ();
					}
				}
				t [5] = Time.realtimeSinceStartup;


				for (int i = 0; i < count; i++) {
					_player = FindObjectOfType<Player> ();
				}
				t [6] = Time.realtimeSinceStartup;

				Debug.Log ("Find:" + (t [1] - t [0]));
				Debug.Log ("FindGameObjectWithTag:" + (t [2] - t [1]));
				Debug.Log ("FindObjectOfType:" + (t [3] - t [2]));
				Debug.Log ("Find:" + (t [4] - t [3]));
				Debug.Log ("FindGameObjectWithTag:" + (t [5] - t [4]));
				Debug.Log ("FindObjectOfType:" + (t [6] - t [5]));
			} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
				int[] arrayInt = new int[count];
				Vector3[] arrayV3 = new Vector3[count];
				int v;

				t [0] = Time.realtimeSinceStartup;
				for(int i = 0; i < count; i++) {
					arrayInt [i] = arrayInt [i];
				}

				t [1] = Time.realtimeSinceStartup;
				foreach(int x in arrayInt){
					v = x;
				}

				t [2] = Time.realtimeSinceStartup;
				for(int i = 0; i < count; i++) {
					arrayInt [i] = arrayInt [i];
				}

				t [3] = Time.realtimeSinceStartup;
				foreach(int x in arrayInt){
					v = x;
				}
				t [4] = Time.realtimeSinceStartup;

				Debug.Log ("for:" 		+ (t [1] - t [0]));
				Debug.Log ("foreach:" 	+ (t [2] - t [1]));
				Debug.Log ("for:" 		+ (t [3] - t [2]));
				Debug.Log ("foreach:" 	+ (t [4] - t [3]));
			}
			
		}
	}
}