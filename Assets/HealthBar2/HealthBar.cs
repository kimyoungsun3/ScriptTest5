using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthBar2{
	public class HealthBar : MonoBehaviour {
		public float healthMax = 100;
		float health;
		public Transform transHealthBar;
		Vector3 healthV;
		float localScale;

		// Use this for initialization
		void Start () {
			Debug.Log ("1, 2 Plus, Minus");
			health 		= healthMax;
			localScale 	= transHealthBar.localScale.x;
		}

		void Update () {
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				health -= 10;
				if (health < 0) {
					health = 0;
				}

				healthV.Set (health * localScale / healthMax, 1, 1);
				transHealthBar.localScale = healthV;
			} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
				health += 10;
				if (health > healthMax) {
					health = healthMax;
				}
				healthV.Set (health * localScale / healthMax, 1, 1);
				transHealthBar.localScale = healthV;
			}
		}
	}
}
