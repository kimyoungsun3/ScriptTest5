using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HealthBar2{
	public class HealthBar2 : MonoBehaviour {
		public float HEALTH_MAX = 100f;
		float health;
		[SerializeField] Transform transHealthBar;
		[SerializeField] float damage = 10f;
		Vector3 healthSize;
		[SerializeField]float localScaleX = 1f;

		private void Start()
		{
			health		= HEALTH_MAX;
		}

		private void Update()
		{
			//데이미지 값을 넣어준다.
			float _damage = 0;
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				_damage = -damage * Time.deltaTime;
			}
			else if (Input.GetKey(KeyCode.RightArrow))
			{
				_damage = +damage * Time.deltaTime;
			}

			//값을 계산해서 넣어주기...
			if (_damage != 0)
			{
				health += _damage;
				if (health <= 0)
				{
					health = 0;
				}
				else if (health > HEALTH_MAX)
				{
					health = HEALTH_MAX;
				}
				healthSize.Set(health * localScaleX / HEALTH_MAX, 1, 1);
				transHealthBar.localScale = healthSize;
			}
		}
	}
}
