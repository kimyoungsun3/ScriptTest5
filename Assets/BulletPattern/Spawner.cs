using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolManager5;
using UnityEngine.UI;

namespace BulletPattern{
	public class Spawner : MonoBehaviour {
		public Text text;
		public int index = 0;
		public List<SpawnInfo> listSpawnInfo = new List<SpawnInfo> ();
		public SpawnType spawnType = SpawnType.Circle;
		Transform target;

		[Header("공용 변수")]
		int dummy1;
		[Header("Line 변수")]
		int dummy2;
		[Header("Random 변수")]
		int dummy3;

		void Start(){
			NextSpawnInfo(0);

			target = GameObject.FindGameObjectWithTag ("Player").transform;
		}


		void Update () {
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				NextSpawnInfo (-1);
			} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
				NextSpawnInfo (+1);
			}

			//if (Input.GetKeyDown (KeyCode.Space)) {
			if(Input.GetMouseButtonDown(0)){
				switch (spawnType) {
				case SpawnType.Circle:
					StartCoroutine( SpawnCircle () );
					break;
				case SpawnType.Arc:
					StartCoroutine( SpawnArc () );
					break;
				}
			}			
		}

		IEnumerator SpawnArc(){
			Vector3 _center = transform.position;
			Vector3 _pos = Vector3.zero;
			Quaternion _qua;
			SpawnInfo _info = listSpawnInfo [index];

			//circle class info
			int _amount 	= _info.arcAmount;
			WaitForSeconds _w = ( (_info.arcGapTime <= 0) ? null: (new WaitForSeconds(_info.arcGapTime)) );
			int _count 		= _info.arcCount;
			float _radius 	= _info.arcRadius;
			//float _rotateStep= _info.arcAngleStep;
			//float _rotate;
			bool _bTarget 	= _info.arcTarget;
			//Debug.Log(_amount+":" +":" + _count+":" + _radius+":" + _bTarget);
			BulletType _bulletType = _info.bulletType;
			float _delay		= _info.bulletDelayTime;
			float _speed 		= _info.bulletSpeed;
			float _changeTime	= _info.bulletSpeedChangeTime;
			float _changeSpeed	= _info.bulletSpeedChangeSpeed;
			float _missileTime	= _info.bulletMissleTime;
			float _missileTurnInter= _info.bulletMissleTurnInter;
			//Debug.Log(_delay+":" +":" + _speed+":" + _changeTime+":" + _changeSpeed);

			float _angleStep =  _info.arcAngleStep;
			float _angleTotal = (_count - 1) * _angleStep;
			float _angle, _angle2; 				
			if(_bTarget){
				_angle = Util.GetAngleFromDir(target.position - transform.position);
				_angle = _angle - _angleTotal / 2f;
			}else{
				_angle = -90 - _angleTotal / 2f;
			}
			_angle2 = _angle;
			//Debug.Log(_angle+":"  +":" + _angle2 +":" + _angleTotal+":" + _angleStep+":" + _bTarget);
			float _shake = _info.arcShake;

			for (int k = 0; k < _amount; k++) {
				_angle = _angle2;
				_angle += ((k % 2 == 0) ? _shake : -_shake); //Shade Angle
			
				for (int i = 0; i < _count; i++) {
					_pos.Set (
						Mathf.Cos (_angle * Mathf.Deg2Rad),
						Mathf.Sin (_angle * Mathf.Deg2Rad), 
						0
					);
					//Debug.Log (i + ":" + _pos);
					_pos = _pos.normalized;
					_pos = _center + _pos * _radius;
					_qua = Quaternion.Euler (0, 0, _angle);

					EnemyBullet _scp = PoolManager.ins.Instantiate ("EnemyBullet", _pos, _qua).GetComponent<EnemyBullet> ();
					_scp.SetInfo (target, _bulletType, _delay, _speed, _changeTime, _changeSpeed, _missileTime, _missileTurnInter);

					//Debug.Log (i + ":" + _angle + ":" + _scp.transform.eulerAngles.z + ":" + _pos);
					_angle += _angleStep;
				}
				yield return _w;
			}
		}

		IEnumerator SpawnCircle(){
			Vector3 _center = transform.position;
			Vector3 _pos = Vector3.zero;
			Quaternion _qua;
			SpawnInfo _info = listSpawnInfo [index];

			//circle class info
			int _amount 	= _info.circleAmount;
			WaitForSeconds _w = ( (_info.circleGapTime <= 0) ? null: (new WaitForSeconds(_info.circleGapTime)) );
			int _count 		= _info.circleCount;
			float _radius 	= _info.circleRadius;
			float _rotateStep= _info.circleRotateStep;
			float _rotate;

			BulletType _bulletType = _info.bulletType;
			float _delay		= _info.bulletDelayTime;
			float _speed 		= _info.bulletSpeed;
			float _changeTime	= _info.bulletSpeedChangeTime;
			float _changeSpeed	= _info.bulletSpeedChangeSpeed;
			float _missileTime	= _info.bulletMissleTime;
			float _missileTurnInter= _info.bulletMissleTurnInter;

			float _angleStep = 360f / _count;
			float _angle = -90; 				//0' 부터해야하나 아래부터 해야하므로...
			for (int k = 0; k < _amount; k++) {
				for (int i = 0; i < _count; i++) {
					_pos.Set (
						Mathf.Cos (_angle * Mathf.Deg2Rad),
						Mathf.Sin (_angle * Mathf.Deg2Rad), 
						0
					);
					//Debug.Log (i + ":" + _pos);
					_pos = _pos.normalized;
					_pos = _center + _pos * _radius;
					_qua = Quaternion.Euler (0, 0, _angle);

					EnemyBullet _scp = PoolManager.ins.Instantiate ("EnemyBullet", _pos, _qua).GetComponent<EnemyBullet> ();
					_scp.SetInfo (target, _bulletType, _delay, _speed, _changeTime, _changeSpeed, _missileTime, _missileTurnInter);
			
					//Debug.Log (i + ":" + _angle + ":" + _scp.transform.eulerAngles.z + ":" + _pos);
					_angle += _angleStep;
				}
				_angle += _rotateStep;
				yield return _w;
 
			}
		}


		//---------------------------------------------
		void NextSpawnInfo(int _plus){
			if (_plus != 0) {
				index += _plus;
				if (index < 0) {
					index = listSpawnInfo.Count - 1;
				} else if (index >= listSpawnInfo.Count) {
					index = 0;
				}
			}
			text.text = "[" + index + "]" + listSpawnInfo [index].name;
			spawnType = listSpawnInfo [index].type;
		}
	}
}
