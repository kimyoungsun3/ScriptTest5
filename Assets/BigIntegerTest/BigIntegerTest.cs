using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Keiwando.BigInteger;


namespace BigIntegerTest{
	public class BigIntegerTest : MonoBehaviour {
		public int LOOP_MAX = 26;
		public bool bLoop = false;
		//BigIntegerTest
		// Use this for initialization
		void Start () {
			TestAddition();
			TestExponentiation ();
			CustomTest ();
			StringToBigInteger ();
			StringToBigInteger2 ();
		}			

		void Update(){
			if (bLoop) {
				bLoop = !bLoop;
				StringToBigInteger2 ();
			}
		}

		void StringToBigInteger2(){
			BigInteger _b1 = new BigInteger (1);
			BigInteger _b2 = new BigInteger (10);
			for (int i = 0; i < LOOP_MAX; i++) {
				_b1 = _b1 * _b2;
				Debug.Log (_b1 + ":" + ToStringKR (_b1));
			}
		}

		void StringToBigInteger(){
			string _str = "1234567890123456789012345678901234567890";
			BigInteger _n1 = new BigInteger (_str);
			Debug.Log ("str -> bint:" + _n1);
		}

		void TestAddition() {
			BigInteger number = new BigInteger ("1000");
			var result = BigInteger.Add (number, new BigInteger("1"));
			Debug.Log ("Add:" + result.ToString ());
		}

		void TestExponentiation() {
			BigInteger b 		= 410;
			BigInteger exponent = 29;
			BigInteger result 	= BigInteger.Pow (b, exponent);
			BigInteger result2 	= b.Pow(exponent);
			Debug.Log (b + "^" + exponent + " = " + result);
			Debug.Log (b + "^" + exponent + " = " + result2);
		}

		void CustomTest() {
			BigInteger number = new BigInteger ("1");
			Debug.Log (number.GetDataAsString ());
			Debug.Log (int.MaxValue);
		} 

		//static void Assert(bool condition, string message)
		//{
		//	if (!condition) throw new Exception(message);
		//}
		//-------------------------------------------
		static string[] arrDanga = {
			"",
			"a",  "b",  "c",  "d",  "e", 
			"f",  "g",  "h",  "i",  "j", 
			"k",  "l",  "m",  "n",  "o", 
			"p",  "q",  "r",  "s",  "t", 
			"u",  "v",  "w",  "x",  "y", 
			"z",  
			"aa",  "ab",  "ac",  "ad",  "ae", 
			"af",  "ag",  "ah",  "ai",  "aj", 
			"ak",  "al",  "am",  "an",  "ao", 
			"ap",  "aq",  "ar",  "as",  "at", 
			"au",  "av",  "aw",  "ax",  "ay", 
			"az",  
		};

		public static string ToStringKR(BigInteger _big){
			string _str = "";
			int _idx = 0;
			BigInteger _b1 = new BigInteger (1000);
			BigInteger _b2 = new BigInteger (1000);

			while (true) {
				if (_big <= _b1) {
					_str = arrDanga [_idx];
					break;
				}

				_b1 = _b1 * _b2;
				_idx++;
			}

			return _str;
		}
	}
}
