using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour {
	public float speedMove = 2f;
	public float speedTurn = 90f;
	public float waitTime = .2f;
	public Vector3[] localPoint = new Vector3[0];
	Vector3[] wayPoint = new Vector3[0];
	public float searchTime = 0.5f;
	Coroutine coFollowPath, coFindPlayer;

	//detecting variable
	Light light;
	public LayerMask maskFind;
	public LayerMask maskBlock;
	public QueryTriggerInteraction queryTrigger; 
	//List<Transform> list = new List<Transform>();
	Transform targeting = null;

	void Start () {
		//read light.
		light = GetComponentInChildren<Light> ();

		//find children and waypoint create.
		wayPoint = new Vector3[localPoint.Length]; 
		for (int i = 0; i < wayPoint.Length; i++) {
			wayPoint [i] = transform.position + localPoint[i];
		}

		//Follow way point move....
		//if (coFun != null) {
		//	StopCoroutine (coFun);
		//}
		//coFun = StartCoroutine (CoFollowPath ());
		coFollowPath = StartCoroutine (CoFollowPath ());
		coFindPlayer = StartCoroutine (CoFindPlayer (searchTime));
	}

	Vector3 dir;
	//Quaternion dirQ;
	void Update(){
		if (targeting != null) {
			Debug.DrawLine (transform.position, targeting.position, Color.red);
			//dirQ = Quaternion.LookRotation (targeting.position - transform.position);
			//transform.rotation = Quaternion.Lerp (transform.rotation, dirQ, .1f);
			transform.Translate (Vector3.forward * speedMove * 2 * Time.deltaTime);
			dir = targeting.position - transform.position;
			//dir.y = transform.position.y;
			transform.rotation = Quaternion.LookRotation (dir);
		}
	}


	//Ray ray;
	//RaycastHit hit;
	public float viewAngle = 90f;
	IEnumerator CoFindPlayer(float _waitTime){
		int _len;
		Transform _target;
		Vector3 _dir;
		float _angle, _distance;

		while (true) {
			//list.Clear ();
			targeting = null;
			Collider[] _cols = Physics.OverlapSphere (transform.position, light.range, maskFind);
			_len = _cols.Length;
			for (int i = 0; i < _len; i++) {
				_target = _cols [i].transform;
				_dir = (_target.position - transform.position).normalized;

				_angle = Vector3.Angle (transform.forward, _dir);
				if (_angle < viewAngle / 2f) {
					_distance = Vector3.Distance(_target.position, transform.position);
					if (!Physics.Raycast (transform.position, _dir, _distance, maskBlock)) {
						//Debug.Log ("Find Player");
						//Debug.DrawLine (transform.position, _target.position, Color.red);
						//list.Add(_target);
						GetComponent<Rigidbody>().isKinematic = true;
						targeting = _target;
						light.color = Color.red;
						if(coFollowPath != null)
							StopCoroutine (coFollowPath);
						if(coFindPlayer != null)
							StopCoroutine (coFindPlayer);
					}
				}
			}
			yield return new WaitForSeconds(_waitTime);
		}
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
		//OK
		Quaternion _dirQ = Quaternion.LookRotation(_targetPos - transform.position);
		while (true) {
			transform.rotation = Quaternion.RotateTowards(transform.rotation, _dirQ, speedTurn * Time.deltaTime);
			if (transform.rotation == _dirQ) {
				yield break;
			}
			yield return null;
		}
	}

	//에디터 상태와 실행중 분리...
	//Vector3[] gizmosPos;
	void OnDrawGizmos(){
		if (localPoint.Length <= 0)
			return;

		//waypoint 표시...
		Vector3 _startPos, _previousPos, _pos;
		_previousPos = _startPos = Application.isPlaying ? wayPoint [0] : (transform.position + localPoint [0]);

		for(int i = 0; i < localPoint.Length; i++){
			//foreach (Transform _tran in transform) {
			_pos = Application.isPlaying ? wayPoint [i] : (transform.position + localPoint [i]);
			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere (_pos, .2f);
			Gizmos.DrawLine (_previousPos, _pos);
			_previousPos = _pos;
		}
		Gizmos.DrawLine (_previousPos, _startPos);

		//방향표시...
		Debug.DrawRay (transform.position, transform.up * 2, Color.green);
		Debug.DrawRay (transform.position, transform.right * 2, Color.red);
		Debug.DrawRay (transform.position, transform.forward * 2, Color.blue);

		//각도표시...

		float _radius = Application.isPlaying ? light.range:GetComponentInChildren<Light>().range;
		Quaternion _q;
		_q = Quaternion.Euler (Vector3.up * (transform.eulerAngles.y - viewAngle/2));
		Debug.DrawLine (transform.position, transform.position + _q * Vector3.forward * _radius, Color.green);

		_q = Quaternion.Euler (Vector3.up * (transform.eulerAngles.y + viewAngle/2));
		Debug.DrawLine (transform.position, transform.position + _q * Vector3.forward * _radius, Color.white);

	}
}
