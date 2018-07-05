using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoTest : MonoBehaviour {
	public Transform[] wayPoints;


	void Start () {
		StartCoroutine (CoWayPoints ());
	}

	IEnumerator CoWayPoints(){
		int _idx = 0;
		while (true) {
			yield return StartCoroutine (CoMove (wayPoints [_idx].position, 5f));
			_idx = (_idx + 1) % wayPoints.Length;
		}
	}

	IEnumerator CoMove(Vector3 _destination, float _speed){
		while (transform.position != _destination) {
			transform.position = Vector3.MoveTowards (transform.position, _destination, _speed * Time.deltaTime);
			yield return null;
		}
	}
}
