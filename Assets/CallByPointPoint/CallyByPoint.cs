using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CallByPointPoint{
	public class CallyByPoint : MonoBehaviour {


		void Start () {
			Debug.Log (" == Fun1 ().Fun2 ().Fun3 () ==");
			Fun1 ().Fun2 ().Fun3 ();

			Debug.Log (" == Fun3 ().Fun2 ().Fun1 () ==");
			Fun3 ().Fun2 ().Fun1 ();
		}


		public CallyByPoint Fun1(){
			Debug.Log ("Fun1");
			return this;
		}

		public CallyByPoint Fun2(){
			Debug.Log ("Fun2");
			return this;
		}

		public CallyByPoint Fun3(){
			Debug.Log ("Fun3");
			return this;
		}
	}
}