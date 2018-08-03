using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KinematicMissileStep02{
	public class Missile : MonoBehaviour {
		public float initVelocity;
		public float acceleration;
		float velocity;

		// Use this for initialization
		void Start () {
			velocity = initVelocity;
		}
		
		// Update is called once per frame
		void Update () {
			if (Time.time < Timer.predicatedTime) {
				velocity += acceleration * Time.deltaTime;
				transform.Translate (Vector3.right * velocity * Time.deltaTime);
			}
		}
	}
}
