using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeeOfView{
	public class SeeOfView : MonoBehaviour {
		public LayerMask searchMask;
		public LayerMask maskObstacle;
		public float searchHalfAngle = 15f;
		public float searchRadius = 2f;
		public float searchDelayTime = .5f;
		Coroutine cor;
		void Start () {
			if (cor != null) {
				StopCoroutine (cor);
			}
			cor = StartCoroutine ("FindTarget", searchDelayTime);
		}

		IEnumerator FindTarget(float _delay){
			float _nextTime = Time.time - 1f;
			while (true) {
				if (Time.time > _nextTime) {
					
					//1. 반경 범위내 검사.
					Collider[] _ts = Physics.OverlapSphere (transform.position, searchRadius, searchMask);
					Transform _t;
					Vector3 _dir;
					float _angle, _distance;
					for (int i = 0; i < _ts.Length; i++) {
						_t = _ts [i].transform;

						//2. 나의 시야 각 내인가?.
						//_dir = (_t.position - transform.position).normalized;
						_dir = _t.position - transform.position;
						_angle = Vector3.Angle (transform.forward, _dir);
						Debug.Log (i + ":" + _angle);
						if (_angle < searchHalfAngle) {
							//3. 시야 내에 장애물 검사.
							_distance = _dir.magnitude;
							if (!Physics.Raycast (transform.position, _dir, _distance, maskObstacle)) {
								Debug.Log ("Find > " + _t.gameObject.name);
							}
						}

					}
					_nextTime = Time.time + _delay;

				}

				Quaternion _l = Quaternion.Euler(Vector3.up * (transform.eulerAngles.y - searchHalfAngle));
				Quaternion _r = Quaternion.Euler(Vector3.up * (transform.eulerAngles.y + searchHalfAngle));
				//Debug.DrawRay (transform.position, transform.forward * searchRadius);
				Debug.DrawRay (transform.position, _l * Vector3.forward * searchRadius);
				Debug.DrawRay (transform.position, _r * Vector3.forward * searchRadius);
				yield return null;
			}
		}
	}
}