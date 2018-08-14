using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMTest : MonoBehaviour {
	// Use this for initialization
	void Start () {
		SoundManager1.ins.Play ("BackgroundMusic", -1, true);		
	}

}
