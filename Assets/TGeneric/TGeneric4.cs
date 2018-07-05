using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGeneric4 : MonoBehaviour {

	void Start () {
		Node n = new Node(10);
		Debug.Log (n.d1);
		Debug.Log (n.GetT(11));
		Debug.Log (n.GetData());
	}

	//-----------------------
	class BaseNode<T>{
		public T d1;
	}

	class Node : BaseNode<int>{
		public int d2;

		public Node(int _d1){
			d1 = _d1;
		}

		public int GetT(int t){
			return t;
		}

		public int GetData(){
			return d1;
			//return d1 + d2;
		}
	}
}
