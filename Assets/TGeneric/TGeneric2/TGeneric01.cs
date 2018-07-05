using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGeneric01 : MonoBehaviour {
	
	void Start () {
		Node<string> _n = new Node<string> (10);
		Debug.Log (_n.GetCount ());
		Debug.Log (_n.GetT ("Hello"));
	}

	class BaseNode<T>{
		public int count = 0;
	}

	class Node<T> : BaseNode<int>{
		public Node(int _c){
			count = _c;
		}

		public int GetCount(){
			return count;
		}

		public T GetT(T _t){
			count++;
			return _t;
		}
	}
}
