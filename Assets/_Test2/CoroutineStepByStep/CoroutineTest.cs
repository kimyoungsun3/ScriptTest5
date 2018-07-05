using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoroutineTest : MonoBehaviour {
	public Text messageText;
	string text;
	int count = 0;
	bool bStartEnding = false;

	// Use this for initialization
	IEnumerator Start () {
		Debug.Log ("Start 1");
		yield return StartCoroutine (Step1());
		Debug.Log ("Start 2");
		yield return StartCoroutine (Step2());
		Debug.Log ("Start 3");
		yield return StartCoroutine (Step3());
		bStartEnding = true;
	}

	//
	IEnumerator Step1(){
		int i = 0;
		while(i < 300){
			Debug.Log ("Step1 i:" + i++);
			messageText.text = "loading i:" + i;
			yield return null;
			Debug.Log ("Step1-2 i:" + i);
		}
	}

	IEnumerator Step2(){
		int i = 0;
		while(true){
			Debug.Log ("Step2 i:" + i++);
			messageText.text = "Step2(Y is Next) i:" + i;
			if (Input.GetKeyDown (KeyCode.Y)) {
				break;
			}
			yield return null;
			Debug.Log ("Step2-2 i:" + i);
		}
	}

	IEnumerator Step3(){
		int i = 0;
		while(true){
			Debug.Log ("Step3(anykey) i:" + i++);
			messageText.text = "Step3(anykey) i:" + i;
			if (Input.GetMouseButtonDown (0)) {
				break;
			}
			yield return null;
		}
	}

	// Update is called once per frame
	void Update () {
		Debug.Log ("Update count:" + count);
		if (bStartEnding) {
			messageText.text = "GameManager control";
		}
			
	}
}
