using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameArrowLegend
{
	[System.Serializable]
	public class PlayerData
	{
		public float speed = 2.5f;
		public float radius = 5f;
		public int hitCount = 1;
		public int damage = 1;

		public bool bSide45 = false;
		public bool bSide90 = false;
		public bool bBack = false;
		public int oneShootCount = 1;

	}

	public class Player : MonoBehaviour
	{
		public PlayerData player;
		[SerializeField] LayerMask maskEnemy;
		float searchTime, shootTime;
		Transform targetTrans;
		[SerializeField] float SEARCH_TIME = .5f;
		[SerializeField] float SHOOT_TIME = .5f;
		[SerializeField] float SHOOT_TIME_INNER = .02f;
		[SerializeField] Bullet prefabBullet;

		[SerializeField] Transform spawnPointF, spawnPoint45L, spawnPoint45R, spawnPoint90L, spawnPoint90R, spawnPointB;

		Transform trans;
		Vector3 move;
		Rigidbody rb;

		void Start()
		{
			trans = transform;
			rb = GetComponent<Rigidbody>();
		}

		// Update is called once per frame
		void Update()
		{
			float _h = Input.GetAxisRaw("Horizontal");
			float _v = Input.GetAxisRaw("Vertical");
			move.Set(_h, 0, _v);
			move.Normalize();

			//일정주기로 적을 검색...
			SearchEnemy();


			//이동이 없으면 그때 사격을한다.
			if (_h == 0f && _v == 0 && targetTrans != null && Time.time > shootTime)
			{
				shootTime = Time.time + SHOOT_TIME;

				Vector3 _dir = targetTrans.position - trans.position;
				trans.rotation = Quaternion.LookRotation(_dir);


				StartCoroutine(Co_Shoot(player.oneShootCount));
			}
		}


		private void FixedUpdate()
		{
			if (move != Vector3.zero)
				trans.rotation = Quaternion.LookRotation(move);
			trans.Translate(move * player.speed * Time.deltaTime, Space.World);
		}

		void SearchEnemy()
		{
			//일정 주기로 검색을 한다...
			searchTime -= Time.deltaTime;
			if (searchTime < 0f)
			{
				searchTime = SEARCH_TIME;
				Collider[] _cols = Physics.OverlapSphere(trans.position, player.radius, maskEnemy, QueryTriggerInteraction.Collide);

				//가장 가까운것...
				float _distance = 10000f;
				float _distance2;
				Vector3 _dir;
				for (int i = 0, imax = _cols.Length; i < imax; i++)
				{
					_dir = trans.position - _cols[i].transform.position;
					_distance2 = _dir.magnitude;
					if (_distance > _distance2)
					{
						_distance = _distance2;
						targetTrans = _cols[i].transform;
					}
				}
			}
		}

		IEnumerator Co_Shoot(int _count)
		{

			float _time = 0;
			while (_count > 0)
			{
				if (Time.time < _time)
				{
					yield return null;
					continue;
				}

				//Forward
				Bullet _b = Instantiate(prefabBullet, spawnPointF.position, spawnPointF.rotation) as Bullet;
				_b.Init(player.hitCount, player.damage);

				//45도
				if (player.bSide45)
				{
					_b = Instantiate(prefabBullet, spawnPoint45L.position, spawnPoint45L.rotation) as Bullet;
					_b.Init(player.hitCount, player.damage);

					_b = Instantiate(prefabBullet, spawnPoint45R.position, spawnPoint45R.rotation) as Bullet;
					_b.Init(player.hitCount, player.damage);
				}

				//90도
				if (player.bSide90)
				{
					_b = Instantiate(prefabBullet, spawnPoint90L.position, spawnPoint90L.rotation) as Bullet;
					_b.Init(player.hitCount, player.damage);

					_b = Instantiate(prefabBullet, spawnPoint90R.position, spawnPoint90R.rotation) as Bullet;
					_b.Init(player.hitCount, player.damage);
				}
				//back
				if (player.bBack)
				{
					_b = Instantiate(prefabBullet, spawnPointB.position, spawnPointB.rotation) as Bullet;
					_b.Init(player.hitCount, player.damage);
				}

				_count--;
				_time = Time.time + SHOOT_TIME_INNER;
				yield return null;
			}
		}

		private void OnCollisionExit(Collision collision)
		{
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(transform.position, player.radius);
		}
	}
}