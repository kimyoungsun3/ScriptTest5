using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathfRoundToInt : MonoBehaviour {
	void Start () {
		float x = 0;
		for (int i = 0, iMax = 100; i < iMax; i++) {
			Debug.Log (x
				+ ",  (int):" + ((int)x)
				+ ", .Round:" + (Mathf.Round (x))
				+ ", .RoundToInt:" + (Mathf.RoundToInt (x)) 
			);
			x += 0.05f;
		}
		
	}
}
