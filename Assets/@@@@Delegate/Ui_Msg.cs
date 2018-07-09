using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_Msg : MonoBehaviour {
	UILabel label;
	public static Ui_Msg ins;

	void Awake(){
		ins = this;
		label = GetComponent<UILabel> ();
	}

	public void SetPoint(string _msg){
		label.text = _msg;
	}
}
