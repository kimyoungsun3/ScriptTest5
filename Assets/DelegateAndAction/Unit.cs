using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
	public Transform target;
	public Vector3[] path;
	int index;
	Vector3 curPoint;
	Coroutine cor;
	Transform trans;
	public float speed = 5f;

	public void SetInit(Transform _target){
		target = _target;
	}

	void Start () {
		//Debug.Log ("Unit Start");
		trans = transform;
		PathRequestManager.RequestPath (transform.position, target.position, OnPathFound);	
	}

	void OnPathFound(Vector3[] _wp, bool _bFind){
		//Debug.Log ("Unit OnPathFound");
		if (_bFind) {
			path = _wp;

			if (cor != null) {
				StopCoroutine (cor);
			}
			cor = StartCoroutine (CoMove());
		}
	}


	IEnumerator CoMove(){
		//Debug.Log ("Unit CoMove");
		curPoint = path [0];

		while (true) {
			if(transform.position == curPoint){
				index = (index + 1);
				if (index >= path.Length - 1) {
					//yield break;
					System.Array.Reverse(path);
					index = 0;
				}
				curPoint = path [index];
			}
			trans.position = Vector3.MoveTowards (trans.position, curPoint, speed * Time.deltaTime);
			yield return null;
		}
	}

	void OnDrawGizmos(){
		if (Application.isPlaying && path != null) {
			for (int i = 1; i < path.Length; i++) {
				Gizmos.DrawLine (path [i - 1], path [i]);
			}
		}
	}
}
