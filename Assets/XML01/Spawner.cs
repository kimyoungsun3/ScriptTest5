using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM6;
using Step99;

namespace XMLTest01
{
	public class Spawner : MonoBehaviour
	{
		public int count = 10;
		public float radius = 10f;
		public int itemcodeA = 10001;
		public int itemcodeB = 10003;
		public List<Step99.Enemy> listEnemy = new List<Step99.Enemy>();

		// Update is called once per frame
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				StartCoroutine(Co_SpanwerObject(itemcodeA));
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				StartCoroutine(Co_SpanwerObject(itemcodeB));
			}
		}

		IEnumerator Co_SpanwerObject(int _itemcode)
		{
			Vector3 _pos	= Vector3.zero;
			Quaternion _rot = Quaternion.identity;
			Step99.Enemy _scp;
			MonsterData _monsterData = GameData.ins.GetMonsterData(_itemcode);
			GameObject _prefab = _monsterData.goFileData;
			for (int i = 0; i < count; i++)
			{
				
				_pos.Set(Random.Range(-radius, +radius), 0, Random.Range(-radius, +radius));
				_scp = Instantiate(_prefab, _pos, _rot).GetComponent<Step99.Enemy>(); ;
				listEnemy.Add(_scp);

				//MonsterData -> Enmey Script에 넣어서 세팅... 
				//_scp.SetData(_monsterData).... 안에서 일일이 연결...
				//여기서는 다른것들과 연결되어 있어서...
				_scp.enemyData.health		= _monsterData.health;
				_scp.enemyData.attackTime	= _monsterData.attacktime;
				switch (_monsterData.type)
				{
					case eMonsterType.GroupA:
						_scp.gameObject.layer = 20;
						//_scp.maskTarget = LayerMask.GetMask("Players", "EnemyB");
						break;
					case eMonsterType.GroupB:
						_scp.gameObject.layer = 21;
						//_scp.maskTarget = LayerMask.GetMask("Players", "EnemyA");
						break;
				}
				_scp.enemyData.attackPower		= _monsterData.attackpower;
				_scp.enemyData.attackSpeed		= _monsterData.attackspeed;
				_scp.enemyData.waitTime			= _monsterData.waittime;
				_scp.enemyData.speedMove		= _monsterData.speedmove;
				_scp.enemyData.speedChase		= _monsterData.speedchase;
				_scp.enemyData.speedTurn		= _monsterData.speedturn;
				_scp.enemyData.radius			= _monsterData.radius;
				_scp.enemyData.radiusAttack		= _monsterData.radiusattack;
				_scp.enemyData.radiusToRelease	= _monsterData.radiustorelease;
				yield return null;
			}
		}
	}
}
