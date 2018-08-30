using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIPeople{
	public class WayPoint : MonoBehaviour {
		public static WayPoint ins { get; private set; }
		List<Transform> list = new List<Transform>();

		void Awake(){
			ins = this;
		}

		void Start () {
			foreach (Transform _t in transform) {
				list.Add (_t);
			}
		}

		public Transform GetPoint(){
			return list [Random.Range(0,  list.Count -  1)];
		}
	}
}