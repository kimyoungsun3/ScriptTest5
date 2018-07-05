using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoTest2 : MonoBehaviour {
	public Transform[] wayPoints;
	Transform myTrans;

	void Start () {
		myTrans = transform;
		StartCoroutine (CoWayPoints ());
	}

	IEnumerator CoWayPoints(){
		int _idx = 0;
		Vector3 _destination = wayPoints [_idx].position;
		float _speed = 5f;
		while (true) {
			if (myTrans.position == _destination) {
				_idx = (_idx + 1) % wayPoints.Length;
				_destination = wayPoints [_idx].position;
			}
			myTrans.position = Vector3.MoveTowards (myTrans.position, _destination, _speed * Time.deltaTime);
			yield return null;
		}
	}
}
