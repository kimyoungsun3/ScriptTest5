using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Step99
{
	public class EnemyBridge : MonoBehaviour
	{
		Enemy enmey;
		private void Start()
		{
			enmey = GetComponentInParent<Enemy>();
		}

		public void Invoke_TakeDamage()
		{
			if(enmey != null)
				enmey.Invoke_TakeDamage();
		}
	}
}
