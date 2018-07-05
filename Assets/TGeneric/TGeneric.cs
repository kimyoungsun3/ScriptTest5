using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGeneric : MonoBehaviour {

	void Start () {
		Node n = new Node (10);
		Debug.Log (n.d1);
	}

	//-----------------------
	class BaseNode{
		public int d1;
	}

	class Node : BaseNode{
		public Node(int _d1){
			d1 = _d1;
		}
	}
}
