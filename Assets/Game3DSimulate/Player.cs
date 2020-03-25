using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Step99
{
	[System.Serializable]
	public class PlayerData
	{
		[Space]
		public float health = 100f;
		public float attackTime = 2f;
		public float attackPower = 5f;

		[Space]
		public float speedMove = 3f;
		public float speedTurn = 180f;

		[Space]
		public float radiusAttack = 1.5f;

	}

	public class Player : MonoBehaviour, IDamageable
	{
		public LayerMask mask;
		public PlayerData playerData;
		Vector3 move;
		Transform trans;
		Camera camera;
		Enemy targetScp;
		float attactTimeNext;

		void Start()
		{
			trans	= transform;
			camera	= Camera.main;
		}

		// Update is called once per frame
		void Update()
		{
			float _h = Input.GetAxisRaw("Horizontal");
			float _v = Input.GetAxisRaw("Vertical");

			//이동...
			if(_h != 0)	trans.Rotate(_h * Vector3.up * playerData.speedTurn * Time.deltaTime);
			if(_v != 0)	trans.Translate(_v * Vector3.forward * playerData.speedMove * Time.deltaTime);

			if (Input.GetMouseButtonDown(0))
			{
				targetScp = null;
				Ray _ray = camera.ScreenPointToRay(Input.mousePosition);
				RaycastHit _hit;
				if (Physics.Raycast(_ray, out _hit, 100f, mask, QueryTriggerInteraction.Collide))
				{
					CheckEnemy(_hit);
				}
			}
		}

		void CheckEnemy(RaycastHit _hit)
		{
			Enemy _scp = _hit.collider.GetComponent<Enemy>();
			if (_scp != null)
			{
				targetScp		= _scp;
				Vector3 _dir	= _hit.point - trans.position;
				float _distance = _dir.magnitude;
				if (Time.time > attactTimeNext && _distance < playerData.radiusAttack)
				{
					attactTimeNext = Time.time + playerData.attackTime;
					targetScp.TakeDamage(playerData.attackPower);
					Debug.Log("@@@@ 적에게 데미지주기");
				}
			}
		}

		public void TakeDamage(float _damaged)
		{
			playerData.health -= _damaged;
			if (playerData.health <= 0f)
			{
				Debug.Log("@@@@Player Die");
			}
		}

		private void OnDrawGizmosSelected()
		//private void OnDrawGizmos()
		{
			if (playerData == null) return;
			Gizmos2.DebugCircle(transform.position, playerData.radiusAttack, Color.red);

		}
	}
}
