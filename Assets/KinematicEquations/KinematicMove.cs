using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicMove : MonoBehaviour {
	public float initialVelocity;
	public float acceleration;
	float currentVelocity;
	//bool bStart;
	float predictedTime = 0;

	void Start () {
		currentVelocity = initialVelocity;
		Debug.Log (Time.fixedTime);
	}

	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			predictedTime = Time.fixedTime + Monitor.predictedTime;
			FindObjectOfType<Monitor> ().Init ();
			Debug.Log ("StartTime:" + Time.fixedTime);
			Debug.Log ("PredictedTime:" + predictedTime);
		}

		//Debug.Log (Time.fixedTime +":"+ Monitor.predictedTime);
		if (Time.fixedTime < predictedTime) {
			currentVelocity += acceleration * Time.fixedDeltaTime;
			transform.Translate (Vector3.right * currentVelocity * Time.fixedDeltaTime);
		}
	}

	void OnTriggerEnter(Collider _col){
		Debug.Log ("[Trigger]" + name + ":" + Time.fixedTime);
		//bStart = false;
	}
}
