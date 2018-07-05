using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTest : MonoBehaviour {
	public Text text1, text2, text3, text4;
	float t1, t2, t3;

	void Start () {
		
	}
	
	void Update () {
		t1 += Time.deltaTime;
		t2 += Time.unscaledDeltaTime;
		t3  = Time.time;
		text1.text = t1.ToString ("F3");
		text2.text = t2.ToString ("F3");
		text3.text = t3.ToString ("F3");
		text4.text = Time.timeScale.ToString();

		if(Input.GetMouseButtonDown(0)){
			Time.timeScale += 1f;
			if (Time.timeScale >= 10) {
				Time.timeScale = 0f;
			}
		}
	}
}

