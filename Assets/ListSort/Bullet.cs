using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _ListSort
{
	public class Bullet : MonoBehaviour {
		[SerializeField] float speed = 20f;
		[SerializeField] Enemy enemy;
		Transform enemyTrans;
		GameObject enemyGO;
		float moveDistance;
		Transform trans;
		float damage;


		public void SetData(Enemy _enemy, float _damage = 10f)
		{
			gameObject.SetActive(true);
			trans		= transform;
			damage		= _damage;

			enemy		= _enemy;
			enemyTrans	= enemy.transform;
			enemyGO		= enemy.gameObject;
		}

		// Update is called once per frame
		void Update() {
			float _move = speed * Time.deltaTime;
			moveDistance += _move;

			if(enemy == null || enemyGO.activeSelf == false)
			{
				Destroy(gameObject);
				return;
			}

			if (_move > Vector3.Distance(trans.position, enemyTrans.position))
			{
				enemy.TakeDamage(damage);
				Destroy(gameObject);
			}

			Vector3 _dir = (enemyTrans.position - trans.position).normalized;
			trans.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg);
			trans.Translate(Vector3.right * _move);
		}
	}
}