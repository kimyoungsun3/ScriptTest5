using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour {
	PathRequestManager manager;
	Coroutine cor;

	//void Start(){
	//	Debug.Log ("PathFinding Start");
	//}


	public void StartFindPath(Vector3 _sp, Vector3 _ep){
		//Debug.Log ("PathFinding StartFindPath");
		if (manager == null) {
			manager = GetComponent<PathRequestManager> ();
		}

		if (cor != null) {
			StopCoroutine (cor);
		}
		cor = StartCoroutine (CreatePath(_sp, _ep));
	}


	IEnumerator CreatePath(Vector3 _sp, Vector3 _ep){
		//Debug.Log ("PathFinding CreatePath");
		Vector3[] _wp = new Vector3[5];
		bool _bFind = false;
		int _index = 0;
		Vector3 _dir = _ep - _sp;
		float _distance = _dir.magnitude / _wp.Length;
		//Debug.Log (_dir.magnitude
		//	+ ":" + _wp.Length
		//	+ ":" + _distance
		//	+ ":" + _dir.normalized
		//);
		_dir = _dir.normalized;

		while (true) {
			if (_index >= _wp.Length) {
				_bFind = true;
				break;
			}
			_wp [_index] = _sp + _dir * _distance * (_index + 1);
			_index++;

			yield return null;
		}
		manager.FinishedProcessingPath(_wp, _bFind);
	}
}
