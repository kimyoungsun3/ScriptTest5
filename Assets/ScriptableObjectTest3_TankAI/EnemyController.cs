using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest3{
	public class EnemyController : MonoBehaviour {
		public State stateCurrent, stateRemain;
		public StateInfo stateInfo;
		public Projectile bullet;

		[HideInInspector] public Transform trans;
		public Vector3[] wayLocal;
		[HideInInspector] public Vector3[] wayWorld;
		[HideInInspector] public int wayIndex;
		[HideInInspector] public Transform target;
		float nextTime;

		void Start(){
			trans = transform;

			wayWorld = new Vector3[wayLocal.Length];
			for (int i = 0; i < wayLocal.Length; i++) {
				wayWorld [i] = trans.position + wayLocal [i];
			}
		}

		void Update () {
			if (stateCurrent != null) {
				//Debug.Log (this + ":Update:");
				stateCurrent.UpdateState (this);
			}
		}

		public void SetState(State _nextState){
			if(_nextState != stateRemain){
				stateCurrent = _nextState;
				InitTime ();
			}
		}

		public void InitTime(){
			nextTime 		= 0;
			nextShootTime 	= 0;
		}

		public void SetTargeting(Transform _target){
			target = _target;
			lockOnTime = 0;
		}

		public bool CheckLockOnTime(float _duration){
			lockOnTime += Time.deltaTime;
			return (lockOnTime < _duration);
		}

		float nextShootTime, lockOnTime;
		public void Shoot(){
			//Debug.Log (this + ":Shoot:" + Time.time + ":" + nextShootTime);
			if (Time.time > nextShootTime) {
				//Debug.Log (" > ");
				lockOnTime = 0;
				nextShootTime = Time.time + stateInfo.attackRate;
				Projectile _scp = PoolManager5.PoolManager.ins.Instantiate (bullet.gameObject, trans.position, trans.rotation).GetComponent<Projectile> ();
				_scp.SetSpeedAndShoot (stateInfo.bulletSpeed, stateInfo.bulletDamage);
			}
		}


		void OnDrawGizmos(){
			if (stateCurrent != null && trans != null) {
				//Debug.Log (stateCurrent.color);
				Gizmos.color = stateCurrent.gizmosColor;
				Gizmos.DrawWireCube (trans.position, trans.localScale * 1.5f);
				//Gizmos.DrawRay (trans.position, trans.forward * 5f);
				//Debug.DrawRay (transform.position, transform.forward * 5f, Color.white);
			}
		}

	}
}