using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMPlayer : MonoBehaviour {
	public int playerNumber = 1;

	// Use this for initialization
	void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			SoundManager1.ins.Play ("EngineIdle", playerNumber, true);
			//Debug.Log (playerNumber + "번유저 EngineIdle");
		}else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			SoundManager1.ins.Play ("ShotFiring", playerNumber, false);
			//Debug.Log (playerNumber + "번유저 ShotFiring");
		}
	}
}
