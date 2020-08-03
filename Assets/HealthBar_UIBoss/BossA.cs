using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _HealthBar_UIBoss
{
	public class BossA : MonoBehaviour
	{
		public float healthMax = 100f;
		float health;
		public float hitValue = 2f;
		// Use this for initialization
		void Start()
		{
			health = healthMax;
			Ui_HealthBar.ins.SetInit("불의신전의 마녀");
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				health -= hitValue;
				float _value = health / healthMax;
				if (health < 0f)
					_value = 0;
				Ui_HealthBar.ins.SetHit(_value);
			}
			else if (Input.GetMouseButtonDown(1))
			{
				health += hitValue;
				float _value = health / healthMax;
				if (health < 0f)
					_value = 0;
				Ui_HealthBar.ins.SetHit(_value);
			}
		}
	}
}