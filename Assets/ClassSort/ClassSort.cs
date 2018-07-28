using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ClassSort : MonoBehaviour {
	// Use this for initialization
	void Start () {
		List<NodeClass> list = new List<NodeClass> ();
		list.Add(new NodeClass("kim", 10));
		list.Add(new NodeClass("le", 1));
		list.Add(new NodeClass("bak", 20));
		list.Sort ();

		for (int i = 0; i < list.Count; i++) {
			Debug.Log (list [i].name + " " + list [i].power);
		}			
	}


	public class NodeClass : IComparable<NodeClass>{
		public string name;
		public int power;

		public NodeClass(string _n, int _p){
			name = _n;
			power = _p;
		}

		public int CompareTo(NodeClass _n){
			if (_n == null)
				return -1;
			return power - _n.power;
		}
	}
}
