using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolManager5;

namespace DelegateManager{
	public class EnemySpawner : MonoBehaviour {
		public static EnemySpawner ins;
		Vector2 rangeMax;
		float nextTime;
		public float NEXT_CREATE_TIME = 0.5f;


		void Awake(){
			ins = this;
		}

		void Start(){
			Camera _c = Camera.main;
			rangeMax.Set (_c.orthographicSize * _c.aspect, _c.orthographicSize);
		}


		//-----------------------------------
		public void CreateEnemy(){
			if (Time.time > nextTime) {
				nextTime = Time.time + NEXT_CREATE_TIME;

				Vector2 _pos = new Vector2 (Random.Range (-rangeMax.x, rangeMax.x), Random.Range (-rangeMax.y, rangeMax.y));
				Enemy _scp = PoolManager.ins.Instantiate ("Enemy", _pos, Quaternion.identity).GetComponent<Enemy>();
				//_scp.
			}
		}
	}
}