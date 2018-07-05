using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSharpTest : MonoBehaviour {
	public delegate void VOID_FUN_STRING(string _str);
	VOID_FUN_STRING cb;

	void Start () {
		
		cb = CBDisplay;
		if (cb != null) {
			cb ("Hello1");
			Debug.Log (cb != null);
			cb = null;
		}

		bool _wait = true;
		cb = delegate(string _str) {
			Debug.Log (_str);
			_wait = false;
			cb = null;
		};
		if (cb != null) {
			cb ("Hello2");
			Debug.Log (cb != null);
			cb = null;
		}

		cb = ((_str) => {
			Debug.Log (_str);
			cb = null;
		});
		if (cb != null) {
			cb ("Hello3");
			Debug.Log (cb != null);
			cb = null;
		}



		/*
		MyClass _obj = new MyClass (11);
		MyClass _a = _obj as MyClass;
		Debug.Log (_a.xxx);

		MyClass _b = (MyClass)_obj;
		Debug.Log (_b.xxx);

		Debug.Log (_b is MyClass);
		*/

		//int? i = null;
		//string _str = "Hello";
		//_str.Length

		//Debug.Log ("static:" + TConstant.MAX_STATIC);
		//Debug.Log ("const:" + TConstant.MAX_CONST);

		//StartCoroutine (CoGetNumber ());
	}

	public void CBDisplay(string _str){
		Debug.Log (_str);
	}

	//void Update(){
	//	Debug.Log ("--U--");
	//}

	IEnumerator CoGetNumber(){
		int i = 0;
		while (true) {
			Debug.Log ("--G--");
			if (i++ > 10)
				yield break;
			yield return null;
		}
	}

	public class MyClass{
		public int xxx;

		public MyClass(int _x){
			xxx = _x;
		}
	}

}
