using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CallByValueRef{
	public class CallByValueRef : MonoBehaviour {
		public int count = 1000;
		public int plusCount = 1000;
		float[] t = new float[10];
		Vector3 one = Vector3.one;
		public Text text;

	

		// Update is called once per frame
		void Update () {
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				count += plusCount;
				text.text = count.ToString ();
			}

			if (Input.GetKeyDown (KeyCode.Alpha2)) {
				Vector3 _v = Vector3.zero;
				t [0] = Time.realtimeSinceStartup;
				for (int i = 0; i < count; i++) {
					_v += FunCallByValue (one);
				}

				t [1] = Time.realtimeSinceStartup;
				for (int i = 0; i < count; i++) {
					FunCallByReference (ref _v, ref one);
				}

				t [2] = Time.realtimeSinceStartup;
				for (int i = 0; i < count; i++) {
					FunCallByReference (ref _v, ref one);
				}

				t [3] = Time.realtimeSinceStartup;
				for (int i = 0; i < count; i++) {
					_v += FunCallByValue (one);
				}

				t [4] = Time.realtimeSinceStartup;
				Debug.Log ("FunCallByValue:" + (t [1] - t [0]));
				Debug.Log ("FunCallByReference:" + (t [2] - t [1]));
				Debug.Log ("FunCallByReference:" + (t [3] - t [2]));
				Debug.Log ("FunCallByValue:" + (t [4] - t [3]));
			}
				
		}

		Vector3 FunCallByValue(Vector3 _v){
			return _v;
		}

		void FunCallByReference(ref Vector3 _v, ref Vector3 _one){
			_v += _one;
		}
	}
}