using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameArrowLegend
{
	public class Enemy : MonoBehaviour, IDamageable
	{
		public float health = 100f;
		public void Damage(float _damage)
		{
			health -= _damage;
		}
	}
}