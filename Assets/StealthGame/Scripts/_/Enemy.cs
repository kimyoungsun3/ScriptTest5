using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public float speedMove = 2f;
	public float speedTurn = 90f;
	public float waitTime = .2f;
	Vector3[] wayPoint;
	Coroutine coFun;
	//WaitForSeconds waitForTime;

	void Start () {
		//waitForTime = new WaitForSeconds (waitTime);

		//find children and waypoint create.
		wayPoint = new Vector3[transform.childCount]; 
		for (int i = 0; i < wayPoint.Length; i++) {
			wayPoint [i] = transform.GetChild (i).position;
		}

		//Follow way point move....
		if (coFun != null) {
			StopCoroutine (coFun);
		}
		coFun = StartCoroutine (CoFollowPath ());
	}

	//노드를 따라서 이동하기.
	IEnumerator CoFollowPath(){
		transform.position = wayPoint [0];
		transform.rotation = Quaternion.LookRotation (wayPoint [1] - wayPoint [0]);

		int _idx = 1;
		int _len = wayPoint.Length;
		Vector3 _targetPos = wayPoint [_idx];

		while (true) {
			//transform move Target toward.
			transform.position = Vector3.MoveTowards (transform.position, _targetPos, speedMove * Time.deltaTime);

			//change next waypoint 
			if (transform.position == _targetPos) {
				_idx = (_idx + 1) % _len;
				_targetPos = wayPoint [_idx];
				yield return new WaitForSeconds (waitTime);
				//해당방향으로 턴하기....
				yield return StartCoroutine(CoTurn(_targetPos));
			}
			yield return null;
		}
	}

	//해당 포인터 방향으로 턴하기...
	IEnumerator CoTurn(Vector3 _targetPos){	
		/*	
		//시계방향 OK, 반시계방향 OK 음....
		Vector3 _targetDir = (_targetPos - transform.position).normalized;
		float _targetAngle = 90f - Mathf.Atan2 (_targetDir.z, _targetDir.x) * Mathf.Rad2Deg;
		float _angle;

		//Debug.Log (_targetDir.x + ":" + _targetDir.z);
		//Debug.Log ("b:" + _targetAngle + ":" + transform.eulerAngles.y);
		//Debug.Log (Mathf.DeltaAngle (transform.eulerAngles.y, _targetAngle));
		while (Mathf.Abs(Mathf.DeltaAngle (transform.eulerAngles.y, _targetAngle)) > .05f) {
			_angle = Mathf.MoveTowardsAngle (transform.eulerAngles.y, _targetAngle, speedTurn * Time.deltaTime);
			transform.eulerAngles = Vector3.up * _angle;
			//Debug.Log (Mathf.DeltaAngle (transform.eulerAngles.y, _targetAngle));
			yield return null;
		}
		//Debug.Log ("a:" + _targetAngle + ":" + transform.eulerAngles.y);
		*/

		//OK
		Quaternion _dirQ = Quaternion.LookRotation(_targetPos - transform.position);
		while (true) {
			transform.rotation = Quaternion.RotateTowards(transform.rotation, _dirQ, speedTurn * Time.deltaTime);
			if (transform.rotation == _dirQ) {
				yield break;
			}
			yield return null;
		}

		//X transform.Rotate - 원는 각을 지나 갈수 있다....
		//Quaternion _dirQ = Quaternion.LookRotation(_targetPos - transform.position);
		//while (true) {
		//	transform.Rotate (Vector3.up * speedTurn * Time.deltaTime);
		//	if (transform.rotation == _dirQ) {
		//		yield break;
		//	}
		//	yield return null;
		//}
	}

	//에디터 상태와 실행중 분리...
	void OnDrawGizmos(){
		Vector3 _startPos, _previousPos, _pos;
		_startPos = Application.isPlaying?wayPoint [0]:transform.GetChild(0).position;
		_previousPos = _startPos;

		for(int i = 0; i < transform.childCount; i++){
			//foreach (Transform _tran in transform) {
			_pos = Application.isPlaying?wayPoint [i]:transform.GetChild(i).position;
			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere (_pos, .2f);
			Gizmos.DrawLine (_previousPos, _pos);
			_previousPos = _pos;
		}
		Gizmos.DrawLine (_previousPos, _startPos);

		Debug.DrawRay (transform.position, transform.up * 2, Color.green);
		Debug.DrawRay (transform.position, transform.right * 2, Color.red);
		Debug.DrawRay (transform.position, transform.forward * 2, Color.blue);
	}
}
