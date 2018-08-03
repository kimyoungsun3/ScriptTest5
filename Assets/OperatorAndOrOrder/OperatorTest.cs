using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OperatorAndOrOrder{
	public class OperatorTest : MonoBehaviour {
		public bool rtn = true;
		
		void Start () {
			Debug.Log (string.Format("=========={0}===========", rtn));

			bool _b;
			Debug.Log ("1. A && B || C && D");
			_b = Fun ("A") && Fun ("B") || Fun ("C") && Fun ("D");

			Debug.Log ("2. (A && B) || (C && D)");
			_b = (Fun ("A") && Fun ("B")) || (Fun ("C") && Fun ("D"));


			Debug.Log ("3. A && (B || C) && D");
			_b = Fun ("A") && (Fun ("B") || Fun ("C")) && Fun ("D");
		}

		bool Fun(int _var){
			Debug.Log (_var);
			return rtn;
		}

		bool Fun(string _str){
			Debug.Log (_str);
			return rtn;
		}
	}
}
