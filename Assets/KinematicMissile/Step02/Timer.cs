using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KinematicMissileStep02{

	public class Timer : MonoBehaviour {
		//public static Timer ins { get; private set; }
		public Missile scpA;
		public Missile scpB;
		public static float predicatedTime;

		void Start () {
			float h = scpA.transform.position.x - scpB.transform.position.x;
			float a = scpB.acceleration - scpA.acceleration;
			float b = 2f * (scpB.initVelocity - scpA.initVelocity);
			float c = -2f * h;

			predicatedTime = (-b + Mathf.Sqrt (b * b - 4f * a * c)) / (2f * a);
			Debug.Log ("예상시간:" + predicatedTime);
		}
	}
}
