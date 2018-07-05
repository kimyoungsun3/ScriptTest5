using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathfPingPong : MonoBehaviour {


	void Update () {
		Debug.Log(Time.time + " -> " + Mathf.PingPong (Time.time, 1f));	
	}
}
