using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour {
	public KinematicMove objectA, objectB;
	public static float predictedTime;
	public float plusStartTime = 0.02f;

	void Start () {
		//Debug.Log ("dd" + Time.fixedTime);
		//Time.fixedDeltaTime = Time.fixedTime;
		Init();
	}

	public void Init(){


		float h = Mathf.Abs(objectA.transform.position.x - objectB.transform.position.x);
		//h = 0;

		float a = objectB.acceleration - objectA.acceleration;
		float b = 2f * (objectB.initialVelocity - objectA.initialVelocity);
		float c = -2f * h;

		Debug.Log ("h:" + h
			+ " a:" + a
			+ " b:" + b
			+ " c:" + c
		);

		predictedTime = (-b + Mathf.Sqrt (b * b - 4f * a * c)) / (2f * a) - plusStartTime;
		Debug.Log ("time:" + predictedTime);
	}
}
