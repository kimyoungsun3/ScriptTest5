using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberDisplay1 : MonoBehaviour {
	public Text text;
	public Text text2;

	public AnimationCurve curve;

	public List<Vector2> list = new List<Vector2> ();
	float numSpeed, numStep, numDest;

	// Update is called once per frame

	float numCnt = 0;
	float curTime = 0;
	float stepNum = 0;

	void reset(float d){
		numCnt = 0;
		curTime = 0;
		stepNum = d;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			numSpeed = list [0].x / list [0].y;
			numDest = list [0].x;
			numStep = 0;

			reset (list [0].y);

		}else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			numSpeed = list [1].x / list [1].y;
			numDest = list [1].x;
			numStep = 0;

			reset(list [1].y);

		}else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			numSpeed = list [2].x / list [2].y;
			numDest = list [2].x;
			numStep = 0;

			reset (list [2].y);
		//
		}else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			
			numSpeed = list [3].x / list [3].y;
			numDest = list [3].x;
			numStep = 1;

			reset (list [3].y);

		}else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			numSpeed = list [4].x / list [4].y;
			numDest = list [4].x;
			numStep = 0;

			reset (list [4].y);

		}else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			numSpeed = list [5].x / list [5].y;
			numDest = list [5].x;
			numStep = 0;

			reset (list [5].y);
		}


		if (numStep < numDest) {
			numStep += numSpeed * Time.deltaTime; 

			//curTime += (Time.deltaTime / stepNum);
			//numCnt = (numDest * curve.Evaluate(curTime));


			if (numStep > numDest) {
				numStep = numDest;
			}



			text.text = ((int)numStep).ToString ();
			//text2.text = ((int)numCnt).ToString ();
		}


		curTime += (Time.deltaTime / stepNum);
		numCnt = (numDest * curve.Evaluate(curTime));
		if (curTime >= 1) {
			
			numCnt = numDest;
		}		
		text2.text = ((int)numCnt).ToString ();



	}


}
