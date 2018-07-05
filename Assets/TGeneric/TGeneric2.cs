using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGeneric2 : MonoBehaviour {

	void Start () {
		Node<int> n = new Node<int> (10);
		Debug.Log (n.d1);
		Debug.Log (n.GetT(11));
	}

	//-----------------------
	class BaseNode{
		public int d1;
	}

	class Node<T> : BaseNode{
		public T d2;

		public Node(int _d1){
			d1 = _d1;
		}

		public T GetT(T t){
			return t;
		}
	}
}
