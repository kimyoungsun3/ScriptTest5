using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM6;

namespace Step99
{
	[System.Serializable]
	public class EnemyData
	{
		[Space]
		public float health			= 100f;
		public float attackTime		= 2f;
		public float attackPower	= 5f;
		[Range(0.66f, 3.0f)]
		public float attackSpeed	= 0.66f;
		public float viewAngle		= 130f;

		public float waitTime = 1.5f;

		[Space]
		[Range(.3f, 4.0f)]
		public float speedMove	= 1f;
		public float speedChase	= 1.5f;
		public float speedTurn	= 180f;
		public float searchTime = .5f;

		[Space]
		public float radius				= 3f;
		public float radiusAttack		= 1.5f;
		public float radiusToRelease	= 2f;
	}

	public class Enemy : FSM<Enemy.eEnemyState>, IDamageable
	{
		public enum eEnemyState { None, Wait, Move, Chase, Attack };
		public EnemyData enemyData;

		bool bInit = false;
		Transform trans;
		float searchTimeNext, attackTimeNext, waitTimeNext;
		Animator animator;
		public LayerMask maskTarget;
		public Vector3[] localPoint = new Vector3[0];
		Vector3[] wayPoints = new Vector3[0];
		int wayIndex = 0;
		Vector3 wayPoint;
		Quaternion wayPointRot;
		//int attackHash = Animator.StringToHash("attack");
		int attackFullHash = Animator.StringToHash("Base Layer.attack");

		//[SerializeField] List<Transform> targetList = new List<Transform>();
		Transform target;
		//Enemy targetScp;
		IDamageable targetScp;

		// Use this for initialization
		void Start()
		{
			if (Constant.DEBUG) Debug.Log(this + " Start");

			Init();
		}

		public void Init()
		{
			if (bInit) return;
			bInit = true;

			//레퍼런스 세팅...
			trans		= transform;
			animator	= GetComponentInChildren<Animator>();

			//way point
			int _len = localPoint.Length;
			wayPoints = new Vector3[_len];
			for (int i = 0, imax = _len; i < imax; i++)
			{
				wayPoints[i] = trans.position + localPoint[i];
			}

			//함수 세팅...
			AddState(eEnemyState.Wait,		Init_Wait,		Modify_Wait,	null);
			AddState(eEnemyState.Move,		Init_Move,		Modify_Move,	null);
			AddState(eEnemyState.Chase,		Init_Chase,		Modify_Chase,	null);
			AddState(eEnemyState.Attack,	Init_Attack,	Modify_Attack,	null);

			MoveState(eEnemyState.Wait);
		}

		#region Wait...
		void Init_Wait()
		{
			if (Constant.DEBUG) Debug.Log(this + " Init_Wait");

			//유효범위 벗어남...
			target		= null;
			targetScp	= null;
			waitTimeNext = Time.time + enemyData.waitTime;

			//애니메이션...
			animator.SetInteger("state", 0);
		}

		void Modify_Wait()
		{
			if(target != null)
			{
				MoveState(eEnemyState.Chase);
				return;
			}
			else if (Time.time > waitTimeNext)
			{
				MoveState(eEnemyState.Move);
				return;
			}

			FindEnemyRadius();
		}

		void FindEnemyRadius()
		{
			if (Constant.DEBUG) Debug.Log(this + " FindEnemy");
			if (Time.time > searchTimeNext)
			{
				searchTimeNext = Time.time + enemyData.searchTime;
				Collider[] _cols = Physics.OverlapSphere(trans.position, enemyData.radius, maskTarget);

				if (_cols.Length > 0)
				{
					target = _cols[0].transform;
				}
			}
		}

		void FindEnemy()
		{
			if (Constant.DEBUG) Debug.Log(this + " FindEnemy");
			if (Time.time > searchTimeNext)
			{
				searchTimeNext = Time.time + enemyData.searchTime;

				Transform _target;
				float _angleMaxHalf = enemyData.viewAngle * .5f;
				float _angle, _distance;

				//1.충돌체 검사...
				Collider[] _cols = Physics.OverlapSphere(trans.position, enemyData.radius, maskTarget);
				Vector3 _pos = trans.position;
				Vector3 _dir;
				//targetList.Clear();
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
							if (_target == _hit.transform)
							{
								target = _target;
							}
						}
					}
				}
			}
		}
		#endregion //Wait



		#region Move...
		void Init_Move()
		{
			if (Constant.DEBUG) Debug.Log(this + " Init_Move");
			
			//가장 가까운 곳의 way point를 찾는다...
			if (preState != eEnemyState.Wait)
				wayIndex = GetNearWayPointIndex();
			//Debug.Log(wayIndex);

			//wayIndex
			wayPoint = wayPoints[wayIndex];
			wayIndex++;
			wayIndex = wayIndex % wayPoints.Length;

			Vector3 _dir = wayPoint - trans.position;
			wayPointRot = Quaternion.LookRotation(_dir);

			animator.SetInteger("state", 1);
		}

		//웨포인트 중에서 가장 가까운곳 찾기.
		int GetNearWayPointIndex()
		{
			if (Constant.DEBUG) Debug.Log(this + " GetNearWayPointIndex");
			int _rtn = 0;
			float _distance = float.MaxValue;
			float _distance2;
			Vector3[] _wayPoints = wayPoints;
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
			if (Constant.DEBUG) Debug.Log(this + " Modify_Move");
			if (target != null)
			{
				MoveState(eEnemyState.Chase);
				return;
			}
			else if (trans.position == wayPoint)
			{
				MoveState(eEnemyState.Wait);
				return;
			}
			//속도 + 걷기 동작 일치하기..
			animator.SetFloat("walkspeed", enemyData.speedMove);

			//이동... 검색...
			trans.position = Vector3.MoveTowards(trans.position, wayPoint, enemyData.speedMove * Time.deltaTime);
			trans.rotation = Quaternion.RotateTowards(trans.rotation, wayPointRot, enemyData.speedTurn * Time.deltaTime);

			//적 검색하기...
			FindEnemyRadius();
		}
		#endregion //Move


		#region Chase...
		void Init_Chase()
		{
			if (Constant.DEBUG) Debug.Log(this + " Init_Chase");

			//가장가까운적???....
			targetScp = target.GetComponent<IDamageable>();

			//걸어서 쫒아가는 애니메이션...
			animator.SetInteger("state", 1);

		}

		void Modify_Chase()
		{
			Vector3 _dir	= target.position - trans.position;
			float _distance = _dir.magnitude;
			if (target.gameObject.activeSelf == false ||  _distance > (enemyData.radius + enemyData.radiusToRelease))
			{
				//targetList.Clear();
				MoveState(eEnemyState.Wait);
				return;
			}
			else if(Check_Distance(_distance, enemyData.radiusAttack))
			{
				MoveState(eEnemyState.Attack);
				return;
			}
			_dir.y = 0;

			//바로턴하기...
			//trans.rotation = Quaternion.LookRotation(_dir);
			//trans.Translate(Vector3.forward * enemyData.speedRun * Time.deltaTime);

			//속도 + 걷기 동작 일치하기..
			animator.SetFloat("walkspeed", enemyData.speedMove);

			//턴하면서 이동히가...
			Quaternion _dirQ	= Quaternion.LookRotation(_dir);
			trans.rotation		= Quaternion.RotateTowards(trans.rotation, _dirQ, enemyData.speedTurn * Time.deltaTime);
			trans.Translate(Vector3.forward * enemyData.speedChase * Time.deltaTime);

			//턴하면서 이동히가...
			//Vector3 _dir2 = -_dir;
			//trans.position = Vector3.MoveTowards(trans.position, target.position + _dir2.normalized * enemyData.radiusAttack, enemyData.speedRun * Time.deltaTime);
			//Quaternion _dirRot = Quaternion.LookRotation(_dir);
			//trans.rotation = Quaternion.RotateTowards(trans.rotation, _dirRot, enemyData.speedTurn * Time.deltaTime);
		}

		bool Check_Distance(float _distance, float _radius)
		{
			bool _rtn = false;
			if (_distance < _radius + 0.001f)
			{
				_rtn = true;
			}
			return _rtn;
		}

		#endregion //Chase


		#region Attack...
		void Init_Attack()
		{
			if (Constant.DEBUG) Debug.Log(this + " Init_Attack");
			attackTimeNext = 0;

			//공격은 제자리에서 한다...
			animator.SetInteger("state", 0);

		}


		void Modify_Attack()
		{
			Vector3 _dir	= target.position - trans.position;
			float _distance = _dir.magnitude;
			AnimatorStateInfo _aniInfo = animator.GetCurrentAnimatorStateInfo(0);
			//Debug.Log(_aniInfo.nameHash
			//	+ ":" + _aniInfo.fullPathHash
			//	+ ":" + attackFullHash
			//	+ ":" + attackHash
			//	+ ":" + _aniInfo.tagHash
			//	+ ":" + _aniInfo.IsName("attack")
			//	+ ":" + _aniInfo.IsTag("attack")
			//	+ ":" + _aniInfo.length + ":" + _aniInfo.normalizedTime);


			if(target == null || target.gameObject.activeSelf == false)
			{
				MoveState(eEnemyState.Wait);
				return;
			}
			else if (!Check_Distance(_distance, enemyData.radiusAttack) && _aniInfo.fullPathHash != attackFullHash)
			{
				//공격 범위 내에 들어옴...
				MoveState(eEnemyState.Chase);
				return;
			}

			//해당 방향을 보기...
			Quaternion _dirRot	= Quaternion.LookRotation(_dir);
			trans.rotation		= Quaternion.RotateTowards(trans.rotation, _dirRot, enemyData.speedTurn * Time.deltaTime);

			//일정시간 단위로 공격하기....
			Attack(_dir, _distance);
		}

		void Attack(Vector3 _dir, float _distance)
		{
			if (Time.time > attackTimeNext && Check_Distance(_distance, enemyData.radiusAttack) )
			{
				Debug.Log(" >> attack");
				attackTimeNext = Time.time + enemyData.attackTime;
				animator.SetFloat("attackspeed", enemyData.attackSpeed);
				animator.SetTrigger("attack");
				//if(targetScp != null)
				//	targetScp.TakeDamage(enemyData.attackPower);
			}
		}

		public void Invoke_TakeDamage()
		{
			Debug.Log(">> my >> other take damage");
			if (targetScp != null)
			{
				targetScp.TakeDamage(enemyData.attackPower);
			}
		}

		public void TakeDamage(float _damaged)
		{
			enemyData.health -= _damaged;
			if(enemyData.health <= 0f)
			{
				Debug.Log("@@@@ >> die >> coin획득");
				gameObject.SetActive(false);				
			}
		}

		#endregion //Attack

		//[SerializeField] bool bGizmos;
		private void OnDrawGizmosSelected()
		//private void OnDrawGizmos()
		{
			if (enemyData == null) return;
			//if (!bGizmos) return;
			//시아표시가하기...
			//Gizmos.color = Color.yellow;
			//Gizmos.DrawWireSphere(transform.position, enemyData.radius);
			Gizmos2.DebugCircle(transform.position, enemyData.radius, Color.yellow);

			//Gizmos.color = Color.gray;
			//Gizmos.DrawWireSphere(transform.position, enemyData.radius + enemyData.radiusToRelease);
			Gizmos2.DebugCircle(transform.position, enemyData.radius + enemyData.radiusToRelease, Color.gray);

			//Gizmos.color = Color.red;
			//Gizmos.DrawWireSphere(transform.position, enemyData.radiusNearAttack);
			Gizmos2.DebugCircle(transform.position, enemyData.radiusAttack, Color.red);
		}
	}
}
