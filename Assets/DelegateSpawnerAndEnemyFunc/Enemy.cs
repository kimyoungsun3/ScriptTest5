using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolManager7;

namespace DelegateSpawnerAndEnemyFunc{
	
	public class Enemy : MonoBehaviour {
		//public System.Func<Enemy, EnemySpawner> onDeath;
		//System.Action cbIn;
		System.Func<Enemy, int, bool> cbDeath;
		public Vector2 rangeMax = new Vector2(.5f, .5f);
		public List<EnemyBullet> listEnemyBullet = new List<EnemyBullet> ();
		//---------------------------------------
		void Start(){
			Debug.Log ("5. Instance EnemyBullet");
			Debug.Log ("6. Random destroy EnemyBullet");
			Debug.Log ("7. Delete All EnemyBullet");
		}

		//---------------------------------------
		public void InitFirst(System.Func<Enemy, int, bool>  _cb){
			cbDeath = _cb;
		}

		void Update(){
			if (Input.GetKeyDown (KeyCode.Alpha2)) {
				int _r = Random.Range (0, 100);
				//Debug.Log (_r);
				if (_r < 50) {
					HitAndDeath ();
				}
			}else if (Input.GetKeyDown (KeyCode.Alpha5)) {
				CreateEnemyBullet ();
			} else if (Input.GetKeyDown (KeyCode.Alpha6)) {
				//CreateEnemy ();
				//EnemyBullet  안에서 Random하게 호출....
			} else if (Input.GetKeyDown (KeyCode.Alpha7)) {
				DelAllEnemyBullet ();
			}
		}

		void CreateEnemyBullet(){
			Debug.Log ("Instance EnemyBullet");
			Vector3 _pos = transform.position + (new Vector3 (Random.Range (-rangeMax.x, rangeMax.x), Random.Range (-rangeMax.y, rangeMax.y), transform.position.z));
			EnemyBullet _scp = PoolManager.ins.Instantiate ("EnemyBullet", _pos, Quaternion.identity).GetComponent<EnemyBullet>();

			//callback register and list register.
			_scp.InitFirst (this);
			listEnemyBullet.Add (_scp);
		}

		public void DelEnemyBullet(EnemyBullet _scp){
			if (gameObject.activeSelf) {
				listEnemyBullet.Remove (_scp);
			}
		}

		void DelAllEnemyBullet(){
			for (int i = 0, iMax = listEnemyBullet.Count; i < iMax; i++) {
				listEnemyBullet [i].Destroy ();
			}
			listEnemyBullet.Clear ();
		}

		//-----------------------------------
		void HitAndDeath(){
			if (cbDeath != null) {
				bool _b = cbDeath (this, 1);
				Debug.Log ("CallBack return:" + _b);
				cbDeath = null;
			}

			Destroy ();
		}

		public void Destroy(){
			cbDeath = null;
			gameObject.SetActive (false);
		}
	}
}
