using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGeneric3 : MonoBehaviour {

	void Start () {
		Node<int> n = new Node<int> (10);
		Debug.Log (n.d1);
		Debug.Log (n.GetT(11));
		Debug.Log (n.GetData());
	}

	//-----------------------
	class BaseNode<T>{
		public T d1;
	}

	class Node<T> : BaseNode<T>{
		public T d2;

		public Node(T _d1){
			d1 = _d1;
		}

		public T GetT(T t){
			return t;
		}

		public T GetData(){
			return d1;
			//return d1 + d2;
		}
	}
}
