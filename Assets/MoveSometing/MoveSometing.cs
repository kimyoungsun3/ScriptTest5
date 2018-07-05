using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSometing : MonoBehaviour {
	Transform trans;
	Vector3 befPos, deltaPos;
	List<Transform> list = new List<Transform>();
	public float DISTANCE = 1f;
	public LayerMask mask;

	void Start () {
		trans 	= transform;
		befPos 	= trans.position;
	}


	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			list.Clear ();
			Collider[] _cols = Physics.OverlapSphere (trans.position, DISTANCE, mask);
			for (int i = 0, _len = _cols.Length; i < _len; i++) {
				list.Add (_cols [i].transform);
			}
		} else if (Input.GetMouseButtonDown (1)) {
			if (list.Count > 0) {
				list.RemoveAt(0);
			}
		}

		if (list.Count > 0) {
			deltaPos = trans.position - befPos;
			for (int i = 0, _len = list.Count; i < _len; i++) {
				list [i].position += deltaPos;
				//list [i].position = trans.TransformPoint(delta);
			}
		}

		befPos = trans.position;			
	}


	void OnDrawGizmos(){
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (transform.position, DISTANCE);
	}
}
