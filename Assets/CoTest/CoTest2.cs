using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoTest2 : MonoBehaviour {
	public Transform[] wayPoints;
	Transform trans;

	void Start () {
		trans = transform;
		StartCoroutine (Co_WayPoints ());
	}

	IEnumerator Co_WayPoints(){
		int _idx = 0;
		Vector3 _destination = wayPoints [_idx].position;
		float _speed = 5f;
		float _waitTime = 0;
		while (true) {
			if (trans.position == _destination) {
				_idx = (_idx + 1) % wayPoints.Length;
				_destination = wayPoints [_idx].position;
				_waitTime = 1f;
			}


			if(_waitTime > 0f)
			{
				_waitTime -= Time.deltaTime;
			}
			else
			{
				trans.position = Vector3.MoveTowards(trans.position, _destination, _speed * Time.deltaTime);
			}			
			yield return null;
		}
	}
}
