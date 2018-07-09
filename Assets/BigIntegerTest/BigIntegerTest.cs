using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Keiwando.BigInteger;


namespace BigIntegerTest{
	public class BigIntegerTest : MonoBehaviour {
		public int LOOP_MAX = 26;
		public bool bLoop = false;
		public BigInteger num;
		//BigIntegerTest
		// Use this for initialization
		void Start () {
			//-------------------
			BigInteger num1 = new BigInteger (1000000);
			BigInteger num2 = new BigInteger (1000);
			BigInteger num3 = num1 + num2;
			Debug.Log ("plus:" + (num1 + num2));
			Debug.Log ("plus:" + num3);
			Debug.Log ("minus:" + (num1 - num2));
			Debug.Log ("mul:" + (num1 * num2));
			Debug.Log ("div:" + (num1 % num2));
			Debug.Log ("plus:" + num3);


			//-------------------
			BigInteger number = new BigInteger ("1000");
			BigInteger result = BigInteger.Add (number, new BigInteger("1"));
			Debug.Log (string.Format("Add:{0}", result));

			//----------------------
			BigInteger b 		= 410;						//<---------
			BigInteger exponent = 29;						//<---------
			BigInteger r1 	= BigInteger.Pow (b, exponent);
			BigInteger r2 	= b.Pow(exponent);				//<---------
			Debug.Log (b + "^" + exponent + " = " + r1);
			Debug.Log (b + "^" + exponent + " = " + r2);
			BigInteger x1 = 10;
			BigInteger e1 = 10;
			Debug.Log (x1.Pow (e1));
			//Debug.Log (x1.Pow (10));
			//Debug.Log (x1.Pow ("10"));


			//-------------------------------------
			BigInteger number2 = new BigInteger ("1");
			Debug.Log (number2.GetDataAsString ());
			Debug.Log (int.MaxValue);

			//-------------------------------------
			string _str = "1234567890123456789012345678901234567890";
			BigInteger _n1 = new BigInteger (_str);
			Debug.Log ("str -> bint:" + _n1);

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
