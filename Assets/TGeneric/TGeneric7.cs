using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TGeneric7 : MonoBehaviour {

	void Start () {
		List<Node> list = new List<Node> ();

		list.Add (new Node (1f,  0f));
		list.Add (new Node (1f, -1f));
		list.Add (new Node (1f, +1f));
		list.Sort ();

		for (int i = 0; i < list.Count; i++)
			Debug.Log (i + " => " + list [i].ToString());
	}

	//-----------------------
	public interface IHeapNodeable<T> : IComparable<T>{
		int heapIndex{ get; set; }
	}

	public class Node : IHeapNodeable<Node>{
		public float x1, x2;

		public Node(float _x1, float _x2){
			x1 = _x1;
			x2 = _x2;
		}

		int heapIndex_;
		public int heapIndex {
			get { return heapIndex_;  }
			set { heapIndex_ = value; }
		}

		public int CompareTo(Node _other){
			Debug.Log (x1 + ":" + x2 
				+ " ~ " 
				+ _other.x1+ ":" + _other.x2);
			
			int _rtn = x1.CompareTo (_other.x1);
			if (_rtn == 0) {
				_rtn = x2.CompareTo (_other.x2);
			}
			return _rtn;
		}

		public string ToString(){
			return x1 + ", " + x2;
		}
	}
}
