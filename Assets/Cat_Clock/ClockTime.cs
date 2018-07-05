using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClockTime : MonoBehaviour {
	const float hoursToDegrees = 360/12f, 
	minutesToDegrees = 360/60f,
	secondsToDegrees = 360/60f;

	public Transform hours, minutes, seconds;
	public bool analog;

	void Start(){

		TimeSpan time = DateTime.Now.TimeOfDay;
		Debug.Log ("TimeSpan.TotalHours:" + time.TotalHours);
		Debug.Log ("TimeSpan.TotalMinutes:" + time.TotalMinutes);
		Debug.Log ("TimeSpan.TotalSeconds:" + time.TotalSeconds);

		DateTime time2 = DateTime.Now;
		Debug.Log ("DateTime.Hour:" + time2.Hour);
		Debug.Log ("DateTime.Minute:" + time2.Minute);
		Debug.Log ("DateTime.Second:" + time2.Second);
	}


	void Update () {
		if (analog) {
			TimeSpan time = DateTime.Now.TimeOfDay;
			hours.localRotation = Quaternion.Euler (Vector3.forward * (float)time.TotalHours * -hoursToDegrees);
			minutes.localRotation = Quaternion.Euler (Vector3.forward * (float)time.TotalMinutes * -minutesToDegrees);
			seconds.localRotation = Quaternion.Euler (Vector3.forward * (float)time.TotalSeconds * -secondsToDegrees);

		} else {
			DateTime time = DateTime.Now;
			hours.localRotation = Quaternion.Euler (Vector3.forward * time.Hour * -hoursToDegrees);
			minutes.localRotation = Quaternion.Euler (Vector3.forward * time.Minute * -minutesToDegrees);
			seconds.localRotation = Quaternion.Euler (Vector3.forward * time.Second * -secondsToDegrees);
		}
	}
}
