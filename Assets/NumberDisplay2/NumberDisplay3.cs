using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberDisplay3 : MonoBehaviour {
	public Text text;
	public List<Vector2> list = new List<Vector2> ();
	public AnimationCurve curve;
	float numSpeed, numPercent, numDest;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			numSpeed = 1f / list [0].y;
			numDest = list [0].x;
			numPercent = 0;
		}else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			numSpeed = 1f / list [1].y;
			numDest = list [1].x;
			numPercent = 0;
		}else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			numSpeed = 1f / list [2].y;
			numDest = list [2].x;
			numPercent = 0;
		}else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			numSpeed = 1f / list [3].y;
			numDest = list [3].x;
			numPercent = 0;
		}else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			numSpeed = 1f / list [4].y;
			numDest = list [4].x;
			numPercent = 0;
		}else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			numSpeed = 1f / list [5].y;
			numDest = list [5].x;
			numPercent = 0;
		}

		if (numPercent < 1) {
			//Debug.Log (Time.realtimeSinceStartup);
			numPercent += numSpeed * Time.deltaTime;
			text.text = ((int)Mathf.Lerp(0, numDest, curve.Evaluate (numPercent))).ToString ();
		}
	}


}
