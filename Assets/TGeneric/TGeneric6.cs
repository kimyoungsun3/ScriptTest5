using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGeneric6 : MonoBehaviour {

	void Start () {
		Node<float> n = new Node<float> ();
		n.d1 = (int)10.55f;
		n.d2 = 10.55f;
		Debug.Log (n.d1);
		Debug.Log (n.d2);
	}

	//-----------------------
	class BaseNode<T>{
		public T d1;
	}

	class Node<T> : BaseNode<int>{
		public T d2;
	}
	//class Node2 : T {
	//}
}
