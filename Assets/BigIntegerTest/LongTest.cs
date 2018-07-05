using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigIntegerTest{
	public class LongTest : MonoBehaviour {
		public int loopCount = 26;

		void Start () {
			long _temp = 1;
			for (int i = 0; i < loopCount; i++) {
				_temp *= 1000;
				Debug.Log (i + ":" + _temp);
			}
		}


		string[] arrDanga = {
			"a",  "b",  "c",  "d",  "e", 
			"f",  "g",  "h",  "i",  "j", 
			"k",  "l",  "m",  "n",  "o", 
			"p",  "q",  "r",  "s",  "t", 
			"u",  "v",  "w",  "x",  "y", 
			"z",  
			"aa", "ab", "ac", "ad", "ae"
		};

		//string ShowDanga(long _v){
			
		//}

	}
}
