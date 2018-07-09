using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;
using PoolManager7;
//using Random=UnityEngine;

namespace DelegateSpawnerAndEnemyAction{
	
	public class EnemySpawner : MonoBehaviour {
		public List<Enemy> listEnemy = new List<Enemy> ();
		Vector2 rangeMax;
		int point;

		void Start(){
			Camera _c = Camera.main;
			rangeMax.Set (_c.orthographicSize * _c.aspect, _c.orthographicSize);

			point 	= 0;
		
			Debug.Log ("1. Instance Enemy");
			Debug.Log ("2. Random destroy Enemy");
			Debug.Log ("3. Delete All Enemy");
		}

		void Update(){
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				CreateEnemy ();
			} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
				//CreateEnemy ();
				//Enemy  안에서 Random하게 호출....
			} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
				DelAllEnemy ();
			}
		}


		//-----------------------------------
		// Create Enemy
		//-----------------------------------
		public void CreateEnemy(){
			Debug.Log ("Instance Enemy");
			Vector2 _pos = new Vector2 (Random.Range (-rangeMax.x, rangeMax.x), Random.Range (-rangeMax.y, rangeMax.y));
			Enemy _scp = PoolManager.ins.Instantiate ("Enemy", _pos, Quaternion.identity).GetComponent<Enemy>();

			//callback register and list register.
			_scp.InitFirst (CBPoint);
			listEnemy.Add (_scp);
		}


		void CBPoint(Enemy _enemy, int _point){
			//Debug.Log ("Point Plus and List delete Enemy class");

			//1. Point Plus
			point += _point;
			Ui_Msg.ins.SetPoint (point.ToString ());

			//2. List delete Enemey.
			bool _b = listEnemy.Remove (_enemy);
			//Debug.Log (" > " + _b);
		}

		//-----------------------------------
		// Random delete enemy
		//	> Enemy in Random
		//-----------------------------------
		//public void RandomDelEnemy(){
		//	Debug.Log ("Random destroy Enemy");
		//}

		//-----------------------------------
		// Delete All Enemey
		//-----------------------------------
		public void DelAllEnemy(){
			//Debug.Log ("Delete All Enemy");
			for (int i = 0, iMax = listEnemy.Count; i < iMax; i++) {
				listEnemy [i].Destroy ();
			}
			listEnemy.Clear ();
		}
	}
}