using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour {
	//Coroutine coroutine;
	public bool bGameing = true;
	public float radius = 10;
	public LayerMask maskFind;
	public LayerMask maskBlock;
	public float angleMax = 60f;

	void Start(){
		StartCoroutine (FindObject (0.5f));
	}


	IEnumerator FindObject(float _waitTime){
		int _len;
		Transform _tran;
		Vector3 _dir;
		float _angle, _distance;
		float _angleMax = angleMax / 2;

		while (bGameing) {
			Collider[] _cs = Physics.OverlapSphere (transform.position, radius, maskFind);
			_len = _cs.Length;

			//1. 충돌체....
			for (int i = 0; i < _len; i++) {
				_tran = _cs [i].transform;
				_dir = (_tran.position - transform.position).normalized;

				//2. 시야검사.
				_angle = Vector3.Angle (transform.forward, _dir);
				if (_angle < _angleMax) {
					_distance = Vector3.Distance (_tran.position, transform.position);
					if (!Physics.Raycast (transform.position, _dir, _distance, maskBlock)) {
						Debug.DrawLine (transform.position, _tran.position, Color.red);
					}
				}
			}
			yield return new WaitForSeconds (_waitTime);
		}

	}

	void OnDrawGizmos(){
		Quaternion _q;

		_q = Quaternion.Euler (Vector3.up * (transform.eulerAngles.y - angleMax/2));
		Debug.DrawLine (transform.position, transform.position + _q * Vector3.forward * radius, Color.green);

		_q = Quaternion.Euler (Vector3.up * (transform.eulerAngles.y + angleMax/2));
		Debug.DrawLine (transform.position, transform.position + _q * Vector3.forward * radius, Color.white);
	}
}
