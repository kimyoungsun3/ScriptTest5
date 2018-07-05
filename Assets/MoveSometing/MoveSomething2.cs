using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSomething2 : MonoBehaviour {
	public class ChildObject{
		public Transform t;
		public Vector3	offset;

		public ChildObject(Transform _t, Vector3 _o){
			t = _t;
			offset = _o;
		}
	}

	Transform trans;
	List<ChildObject> list = new List<ChildObject>();
	int listIndex;
	public int LIST_SIZE = 10;

	public float DISTANCE = 2f;
	public LayerMask mask;

	void Start () {
		trans 	= transform;

		//initialize list
		listIndex = 0;
		for (int i = 0; i < LIST_SIZE; i++) {
			list.Add(new ChildObject (null, Vector3.zero));
		}
	}


	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Collider[] _cols = Physics.OverlapSphere (trans.position, DISTANCE, mask);
			int i, _len;
			listIndex = 0;
			ChildObject _c;
			Transform _t;

			//1. 충돌체들의 offset계산 > List에 넣어두기.
			for (i = 0, _len = _cols.Length ; i < _len; i++) {
				_t = _cols [i].transform;

				_c = list [i];
				_c.t 		= _t;
				_c.offset 	= trans.InverseTransformPoint (_cols [i].transform.position);
				listIndex++;
			}
		} else if (Input.GetMouseButtonDown (1)) {
			if (listIndex > 0) {
				listIndex--;
			}
		}

		//2. 리스트를 순회 하면서 오프셑 길이만큼 유지.
		//   p2 = trans.TransformPoint(offset);
		//   offset -> V3.Lerp(p1, p2, i)
		if (listIndex > 0) {
			Vector3 _pos;
			for (int i = 0; i < listIndex; i++) {
				list [i].t.position = trans.TransformPoint (list [i].offset);
				//_pos = trans.TransformPoint (list [i].offset);
				//list [i].t.position = Vector3.Lerp (list [i].t.position, _pos, Time.deltaTime);
			}
		}
	}


	void OnDrawGizmos(){
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (transform.position, DISTANCE);
	}
}
