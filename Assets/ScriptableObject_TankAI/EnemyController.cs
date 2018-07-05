using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO2;


public class EnemyController : MonoBehaviour {
	public SO2.State stateCurrent, stateRemain;
	public SO2.StateInfo stateInfo;
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
			stateCurrent.UpdateState (this);
		}
	}

	public void SetState(SO2.State _nextState){
		if(_nextState != stateRemain){
			stateCurrent = _nextState;
			InitTime ();
		}
	}

	public void InitTime(){
		nextTime = 0;
	}

	public bool CheckAttackTime(float _t){
		nextTime += Time.deltaTime;
		return (nextTime > _t);
	}

	public void Shoot(){
		//Debug.Log ("@@@@ Attack ");
		Projectile _scp = PoolManager2.ins.Instantiate (bullet.gameObject, trans.position, trans.rotation).GetComponent<Projectile>();
		_scp.SetSpeedAndShoot (stateInfo.bulletSpeed, stateInfo.bulletDamage);
		InitTime ();
	}


	void OnDrawGizmos(){
		if (stateCurrent != null && trans != null) {
			//Debug.Log (stateCurrent.color);
			Gizmos.color = stateCurrent.gizmosColor;
			Gizmos.DrawWireCube (trans.position, trans.localScale * 1.5f);
			Gizmos.DrawRay (trans.position, trans.forward * 5f);
			//Debug.DrawRay (transform.position, transform.forward * 5f, Color.white);
		}
	}

}
