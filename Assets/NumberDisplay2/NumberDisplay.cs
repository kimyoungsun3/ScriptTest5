using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberDisplay : MonoBehaviour {
	public Text text;
	public List<Vector2> list = new List<Vector2> ();
	float numSpeed, numStep, numDest;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			numSpeed = list [0].x / list [0].y;
			numDest = list [0].x;
			numStep = 0;
		}else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			numSpeed = list [1].x / list [1].y;
			numDest = list [1].x;
			numStep = 0;
		}else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			numSpeed = list [2].x / list [2].y;
			numDest = list [2].x;
			numStep = 0;
		}else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			numSpeed = list [3].x / list [3].y;
			numDest = list [3].x;
			numStep = 0;
		}else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			numSpeed = list [4].x / list [4].y;
			numDest = list [4].x;
			numStep = 0;
		}else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			numSpeed = list [5].x / list [5].y;
			numDest = list [5].x;
			numStep = 0;
		}

		if (numStep < numDest) {
			//Debug.Log (Time.realtimeSinceStartup);
			numStep += numSpeed * Time.deltaTime;
			if (numStep > numDest) {
				numStep = numDest;
			}
			text.text = ((int)numStep).ToString ();
		}
	}


}
