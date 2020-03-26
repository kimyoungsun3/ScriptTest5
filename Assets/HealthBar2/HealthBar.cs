using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HealthBar2{
	public class HealthBar : MonoBehaviour {
		public float healthMax = 100;
		float health;
		public Transform transHealthBar;
		Vector3 healthV;
		float localScale;
		[SerializeField] float damage = 10f;

		// Use this for initialization
		void Start () {
			Debug.Log ("<<, >> Plus, Minus");
			health 		= healthMax;
			localScale 	= transHealthBar.localScale.x;
		}

		void Update () {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				health -= damage * Time.deltaTime;
				if (health < 0) {
					health = 0;
				}

				healthV.Set (health * localScale / healthMax, 1, 1);
				transHealthBar.localScale = healthV;
			} else if (Input.GetKey (KeyCode.RightArrow)) {
				health += damage * Time.deltaTime;
				if (health > healthMax) {
					health = healthMax;
				}
				healthV.Set (health * localScale / healthMax, 1, 1);
				transHealthBar.localScale = healthV;
			}
		}
	}
}
