using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberDisplay2 : MonoBehaviour {
	public Text text;
	public List<Vector2> list = new List<Vector2> ();
	float numSpeed = 1f / 1f;
	float numPercent, numDest;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			numDest = list [0].x;
			numPercent = 0;
		}else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			numDest = list [1].x;
			numPercent = 0;
		}else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			numDest = list [2].x;
			numPercent = 0;
		}else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			numDest = list [3].x;
			numPercent = 0;
		}else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			numDest = list [4].x;
			numPercent = 0;
		}else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			numDest = list [5].x;
			numPercent = 0;
		}

		if (numPercent < 1) {
			//Debug.Log (Time.realtimeSinceStartup);
			numPercent += numSpeed * Time.deltaTime;
			text.text = ((int)Mathf.Lerp(0, numDest, numPercent)).ToString ();
		}
	}


}
