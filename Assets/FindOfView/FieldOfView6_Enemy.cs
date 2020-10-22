using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolManager7;

namespace FindOfView
{

	public class FieldOfView6_Enemy : FSM6.FSM<eEnemyState>
	{
		public EnemyData enemyData;

		Transform trans;
		[SerializeField] float angleMax = 60f;
		[SerializeField] LayerMask maskFind;//, maskBlock;
		float waitTime;
		float searchTime;
		float attackTime;
		int wayIndex = 0;
		Vector3 wayPoint;
		Quaternion wayPointRot;
		[SerializeField] List<Transform> targetList = new List<Transform>();
		Transform target;
		Animator animator;

		//근거리 공격...

		//원거리 공격...
		[SerializeField] Transform spawnPoint;

		// Use this for initialization
		void Start()
		{
			//if (Constant.DEBUG_ENEMY)
				Debug.Log(this + " Start");
			Init();

			AddState(eEnemyState.Wait, Init_Wait, Modify_Wait, null);
			AddState(eEnemyState.Move, Init_Move, Modify_Move, null);
			AddState(eEnemyState.Chase, Init_Chase, Modify_Chase, null);
			AddState(eEnemyState.Attack, Init_Attack, Modify_Attack, null);

			MoveState(eEnemyState.Move);
		}

		//초기화...
		public void Init()
		{
			//if(Constant.DEBUG_ENEMY) 
				Debug.Log(this + " Init");

			trans		= transform;
			animator	= GetComponentInChildren<Animator>();

			//way point
			int _len = enemyData.localPoint.Length;
			enemyData.wayPoints = new Vector3[_len];
			for(int i = 0, imax = _len; i < imax; i++)
			{
				enemyData.wayPoints[i] = trans.position + enemyData.localPoint[i];
			}
		}

		#region Wait...
		void Init_Wait()
		{
			//if (Constant.DEBUG_ENEMY)
				Debug.Log(this + " Init_Wait");
			waitTime = Time.time + enemyData.waitTime;
			animator.SetInteger("state", 0);
		}

		void Modify_Wait()
		{
			if (Constant.DEBUG_ENEMY) Debug.Log(this + " Modify_Wait");
			if (targetList.Count > 0)
			{
				MoveState(eEnemyState.Chase);
				return;
			}
			else if (Time.time > waitTime)
			{
				MoveState(eEnemyState.Move);
				return;
			}

			//.. 검색...
			FindEnemy();
		}
		#endregion //wait...

		#region Move...
		void Init_Move()
		{
			//if (Constant.DEBUG_ENEMY)
				Debug.Log(this + " Init_Move");
			

			//가장 가까운 곳의 way point를 찾는다...
			if (preState != eEnemyState.Wait)
				wayIndex = GetNearWayPointIndex();
			//Debug.Log(wayIndex);

			//wayIndex
			wayPoint = enemyData.wayPoints[wayIndex];
			wayIndex++;
			wayIndex = wayIndex % enemyData.wayPoints.Length;

			Vector3 _dir	= wayPoint - trans.position;
			wayPointRot = Quaternion.LookRotation(_dir);

			animator.SetInteger("state", 1);
		}

		//웨포인트 중에서 가장 가까운곳 찾기.
		int GetNearWayPointIndex()
		{
			if (Constant.DEBUG_ENEMY) Debug.Log(this + " GetNearWayPointIndex");
			int _rtn = 0;
			float _distance = float.MaxValue;
			float _distance2;
			Vector3[] _wayPoints = enemyData.wayPoints;
			for (int i = 0, imax = _wayPoints.Length; i < imax; i++)
			{
				_distance2 = Vector3.Distance(trans.position, _wayPoints[i]);
				if (_distance2 < _distance)
				{
					_distance = _distance2;
					_rtn = i;
				}
			}

			return _rtn;
		}

		void Modify_Move()
		{
			if (Constant.DEBUG_ENEMY) Debug.Log(this + " Modify_Move");
			if (targetList.Count > 0)
			{
				MoveState(eEnemyState.Chase); 
				return;
			}
			else if (trans.position == wayPoint)
			{
				MoveState(eEnemyState.Wait);
				return;
			}

			//이동... 검색...
			trans.position = Vector3.MoveTowards(trans.position, wayPoint, enemyData.speedMove * Time.deltaTime);
			trans.rotation = Quaternion.RotateTowards(trans.rotation, wayPointRot, enemyData.speedTurn * Time.deltaTime);

			//적 검색하기...
			FindEnemy();
		}
		#endregion //move...

		#region Chase...
		void Init_Chase()
		{
			//if (Constant.DEBUG_ENEMY)
				Debug.Log(this + " Init_Chase");

			//가장 가까운 적을 찾는다...
			float _distance = float.MaxValue;
			float _distance2;
			for(int i = 0, imax = targetList.Count; i < imax; i++)
			{
				_distance2 = Vector3.Distance(trans.position, targetList[i].position);
				if(_distance2 < _distance)
				{
					_distance = _distance2;
					target = targetList[i];
				}
			}

			//걸어서 쫒아가는 애니메이션...
			animator.SetInteger("state", 1);
		}

		void Modify_Chase()
		{
			if (Constant.DEBUG_ENEMY)
				Debug.Log(this + " Modify_Chase");
			Vector3 _dir = target.position - trans.position;
			float _distance = _dir.magnitude;
			if (_distance > (enemyData.radius + enemyData.radiusMarge))
			{
				//유효범위 벗어남...
				target = null;
				targetList.Clear();
				MoveState(eEnemyState.Move);
				return;
			}
			else if (Check_Distance(_distance, enemyData.radiusAttack))
			{
				//공격 범위 내에 들어옴...
				MoveState(eEnemyState.Attack);
			}

			_dir.y = 0;
			Vector3 _dir2		= -_dir;
			trans.position		= Vector3.MoveTowards(trans.position, target.position + _dir2.normalized * enemyData.radiusAttack, enemyData.speedRun * Time.deltaTime);
			Quaternion _dirRot	= Quaternion.LookRotation(_dir);
			trans.rotation		= Quaternion.RotateTowards(trans.rotation, _dirRot, enemyData.speedTurn * Time.deltaTime);
		}

		//[SerializeField] float aa1, aa2;
		bool Check_Distance(float _distance, float _radius)
		{
			bool _rtn = false;
			if(_distance < _radius + 0.001f)
			{
				_rtn = true;
			}
			return _rtn;
		}

		#endregion //Chase...

		#region Attack...
		void Init_Attack()
		{
			if (Constant.DEBUG_ENEMY)
				Debug.Log(this + " Init_Attack");

			//공격은 제자리에서 한다...
			animator.SetInteger("state", 0);
		}

		void Modify_Attack()
		{
			Vector3 _dir = target.position - trans.position;
			float _distance = _dir.magnitude;
			if (!Check_Distance(_distance, enemyData.radiusAttack))
			{
				//공격 범위 내에 들어옴...
				MoveState(eEnemyState.Chase);
			}

			//해당 방향을 보기...
			Quaternion _dirRot = Quaternion.LookRotation(_dir);
			trans.rotation = Quaternion.RotateTowards(trans.rotation, _dirRot, enemyData.speedTurn * Time.deltaTime);

			//공격하기...
			switch (enemyData.attackType)
			{
				case eEnemyAttack.HandAttack:
					Attack_Hand(_dir, _distance);
					break;
				case eEnemyAttack.GunAttack:
					Attack_Gun(_dir, _distance);
					break;
			}
		}

		void Attack_Hand(Vector3 _dir, float _distance)
		{
			//공격거리 내 + 공격시간...
			//Debug.Log(_dir + ":" + _distance + ":" + enemyData.radiusAttack + ":" + attackTime);
			if (Check_Distance(_distance, enemyData.radiusAttack) && Time.time > attackTime)
			{
				attackTime = Time.time + enemyData.attackTime;
				//Debug.Log("Attack_Hand");
				animator.SetTrigger("attack");
			}
		}

		void Attack_Gun(Vector3 _dir, float _distance)
		{
			//공격거리 내 + 공격시간...
			if (Check_Distance(_distance, enemyData.radiusAttack) && Time.time > attackTime)
			{
				attackTime = Time.time + enemyData.attackTime;
				//Debug.Log("Attack_Gun");
				animator.SetTrigger("attack");
				Attack_Gun_Shoot();
			}
		}

		public  void Attack_Gun_Shoot()
		{
			Bullet _bullet = PoolManager.ins.Instantiate("Bullet", spawnPoint.position, spawnPoint.rotation).GetComponent<Bullet>();
			_bullet.SetSpeed(enemyData.shootSpeed, enemyData.damagePower);
		}
		#endregion //Attack....


		void FindEnemy()
		{
			if (Constant.DEBUG_ENEMY) Debug.Log(this + " FindEnemy");
			if (Time.time > searchTime)
			{
				searchTime = Time.time + enemyData.searchTime;

				Transform _target;
				float _angleMaxHalf = angleMax * .5f;
				float _angle, _distance;

				//1. 충돌체 검사...
				Collider[] _cols = Physics.OverlapSphere(trans.position, enemyData.radius, maskFind);
				Vector3 _pos = trans.position;
				Vector3 _dir;
				targetList.Clear();
				RaycastHit _hit;
				for (int i = 0, _len = _cols.Length; i < _len; i++)
				{
					_target = _cols[i].transform;
					_dir	= _target.position - _pos;

					//2. 시아내인가???...
					_angle = Vector3.Angle(trans.forward, _dir);
					if (_angle <= _angleMaxHalf)
					{
						_distance = _dir.magnitude;
						//3. 사이에 어떤 오브젝트가 있다면....
						if (Physics.Raycast(trans.position, _dir, out _hit, _distance))
						{
							//Debug.Log(_target.name + ":" + _hit.transform.name);
							if(_target == _hit.transform)
							{
								targetList.Add(_target);
							}
						}
					}
				}
			}
		}



		//---------------------------------------------------------
		void DisplayEnemy()
		{
			for (int i = 0, imax = targetList.Count; i < imax; i++)
			{
				Debug.DrawLine(trans.position, targetList[i].position, Color.red);
			}
		}

		[SerializeField] bool bGizmos;
		private void OnDrawGizmosSelected()
		{
			//시아표시가하기...
			//Gizmos.color = Color.yellow;
			//Gizmos.DrawWireSphere(transform.position, enemyData.radius);
			Gizmos2.DebugCircle(transform.position, enemyData.radius, Color.yellow);

			//Gizmos.color = Color.gray;
			//Gizmos.DrawWireSphere(transform.position, enemyData.radius + enemyData.radiusMarge);
			Gizmos2.DebugCircle(transform.position, enemyData.radius + enemyData.radiusMarge, Color.gray);

			//Gizmos.color = Color.red;
			//Gizmos.DrawWireSphere(transform.position, enemyData.radiusNearAttack);
			Gizmos2.DebugCircle(transform.position, enemyData.radiusAttack, Color.red);

			//Gizmos.color = Color.red;
			//Gizmos.DrawWireSphere(transform.position, enemyData.radiusFarAttack);
			//Gizmos2.DebugCircle(transform.position, enemyData.radiusFarAttack, Color.red);
		}

		private void OnDrawGizmos()
		{
			float _angle = angleMax * 0.5f;
			float _angleY = transform.eulerAngles.y;
			Quaternion _rot1 = Quaternion.Euler(Vector3.up * (_angleY - _angle));
			Quaternion _rot2 = Quaternion.Euler(Vector3.up * (_angleY + _angle));

			Vector3 _pos1 = _rot1 * Vector3.forward * enemyData.radius;
			Vector3 _pos2 = _rot2 * Vector3.forward * enemyData.radius;

			Gizmos.color = Color.cyan;
			Gizmos.DrawRay(transform.position, _pos1);
			Gizmos.DrawRay(transform.position, _pos2);


			//시아내의 상대 표시하기...
			if (bGizmos)
			{
				trans = transform;
				if (!Application.isPlaying)
				{
					FindEnemy();
				}
				DisplayEnemy();
			}

			//display way point 
			if (enemyData != null && enemyData.localPoint.Length > 0)
			{
				Vector3[] _localPoint = enemyData.localPoint;
				Vector3[] _wayPoint = enemyData.wayPoints;
				Vector3 _startPos, _prePos, _pos;
				Gizmos.color = Color.cyan;
				bool _isPlaying = Application.isPlaying;
				_prePos = _startPos = _isPlaying ? _wayPoint[0] : (transform.position + _localPoint[0]);
				for (int i = 0, imax = _localPoint.Length; i < imax; i++)
				{
					_pos = _isPlaying ? _wayPoint[i] : (transform.position + _localPoint[i]);
					if (_prePos != _pos)
					{
						Gizmos.DrawLine(_pos, _prePos);
					}
					_prePos = _pos;
				}
				Gizmos.DrawLine(_startPos, _prePos);
			}
		}
	}
}